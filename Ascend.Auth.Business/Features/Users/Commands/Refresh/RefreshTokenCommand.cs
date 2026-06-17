using System.Security.Authentication;
using Ascend.Auth.Business.Abstractions;
using Ascend.Auth.Business.DTOs.Responses;
using Ascend.Auth.Business.Features.Users.Commands.Login;
using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.Business.Options;
using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Constants.Messages;
using MediatR;
using Microsoft.Extensions.Options;

namespace Ascend.Auth.Business.Features.Users.Commands.Refresh;

public record RefreshTokenCommand(string RefreshToken) : ICommand<AuthResponse>;

public class RefreshTokenCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
    IJwtProvider jwtProvider,
    IOptions<RefreshTokenOptions> refreshTokenOptions)
    : IRequestHandler<RefreshTokenCommand, AuthResponse>
{
    public async Task<AuthResponse> Handle(RefreshTokenCommand command, CancellationToken ct)
    {
        var stored = await refreshTokenRepository.GetByTokenAsync(command.RefreshToken);

        if (stored == null || stored.IsRevoked || stored.ExpiresAt <= DateTime.UtcNow)
            throw new AuthenticationException(ErrorMessages.InvalidRefreshToken);

        stored.IsRevoked = true;

        return await LoginUserCommandHandler.IssueTokenPair(
            stored.User!,
            refreshTokenRepository,
            jwtProvider,
            refreshTokenOptions.Value);
    }
}
