using System.Security.Authentication;
using Ascend.Auth.Business.DTOs.Responses;
using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.Business.Options;
using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Constants.Messages;
using Ascend.Auth.Domain.Enums;
using Ascend.Common.Utils.Extensions;
using Ascend.Auth.Domain.Models;
using MediatR;
using Microsoft.Extensions.Options;

namespace Ascend.Auth.Business.Features.Users.Commands.Login;

public record LoginUserCommand(string Email, string Password) : ICommand<AuthResponse>;

public class LoginUserCommandHandler(
    IUserRepository userRepository,
    IRefreshTokenRepository refreshTokenRepository,
    IPasswordHasher passwordHasher,
    IJwtProvider jwtProvider,
    IOptions<RefreshTokenOptions> refreshTokenOptions)
    : IRequestHandler<LoginUserCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(LoginUserCommand command, CancellationToken ct)
    {
        var user = await userRepository.GetUserByEmailAsync(command.Email);
        user.ValidateEntity(ErrorMessages.UserNotFound);

        var passwordValid = passwordHasher.Verify(command.Password, user!.PasswordHash);
        passwordValid.ThrowIfFalse(() => new AuthenticationException(ErrorMessages.FailedToLogin));

        if (user.Status != UserStatus.Active)
            throw new AuthenticationException(ErrorMessages.UserNotActive);

        return await IssueTokenPair(user, refreshTokenRepository, jwtProvider, refreshTokenOptions.Value);
    }

    internal static async Task<AuthResponse> IssueTokenPair(
        User user,
        IRefreshTokenRepository refreshTokenRepository,
        IJwtProvider jwtProvider,
        RefreshTokenOptions options)
    {
        var accessToken = jwtProvider.GenerateAccessToken(user);
        var refreshTokenValue = jwtProvider.GenerateRefreshToken();
        var expiresAt = DateTime.UtcNow.AddDays(options.ExpiryDays);

        await refreshTokenRepository.AddAsync(new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = refreshTokenValue,
            UserId = user.Id,
            ExpiresAt = expiresAt,
            CreatedAt = DateTime.UtcNow,
            IsRevoked = false
        });

        return new AuthResponse(accessToken, refreshTokenValue, expiresAt);
    }
}

