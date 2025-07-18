using System.Security.Authentication;
using Ascend.AuthService.Business.DTOs.Requests;
using Ascend.AuthService.Business.Interfaces;
using Ascend.AuthService.Business.Interfaces.Authentication;
using Ascend.AuthService.DataAccess.Interfaces;
using Ascend.AuthService.Domain.Constants;
using Ascend.AuthService.Domain.Constants.Messages;
using Ascend.AuthService.Domain.Enums;
using Ascend.AuthService.Domain.Extensions;
using Ascend.AuthService.Domain.Models;

namespace Ascend.AuthService.Business.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUserFactory _userEntityFactory;

    public UserService(
        IUserRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IUserFactory userEntityFactory)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _userEntityFactory = userEntityFactory;
    }
    
    public async Task Register(RegisterUserRequest request)
    {
        await UserExistsAsync(request.UserName, request.Email, null);
        
        var hashedPassword = _passwordHasher.Generate(request.Password);

        var user = _userEntityFactory.CreateUser(request.UserName, request.Email, hashedPassword, UserStatus.Inactive);
        
        await _usersRepository.AddAsync(user);
    }

    public async Task<string> Login(LoginUserRequest request)
    {
        var user = await _usersRepository.GetUserByEmailAsync(request.Email);
        user.ValidateEntity(ErrorMessages.UserNotFound);

        var result = _passwordHasher.Verify(request.Password, user!.PasswordHash);
        result.ThrowIfFalse(() => new AuthenticationException(ErrorMessages.FailedToLogin));

        var token = _jwtProvider.Generate(user);

        return token;
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
        var user = await _usersRepository.GetUserByIdAsync(userId);
        user.ValidateEntity(ErrorMessages.UserNotFound);

        return user!;
    }

    private async Task UserExistsAsync(string userName, string email, string? phoneNumber)
    {
        var userNameExists = await _usersRepository.UserNameExistsAsync(userName);
        userNameExists.ThrowIfTrue(() 
            => new InvalidOperationException(ErrorMessages.AlreadyExistsUserName));
        
        var emailExists = await _usersRepository.UserEmailExistsAsync(email);
        emailExists.ThrowIfTrue(() 
            => new InvalidOperationException(ErrorMessages.AlreadyExistsEmail));

        if (phoneNumber != null)
        {
            var phoneNumberExists = await _usersRepository.UserPhoneNumberExistsAsync(phoneNumber);
            phoneNumberExists.ThrowIfTrue(() 
                => new InvalidOperationException(ErrorMessages.AlreadyExistsPhoneNumber));
        }   
    }
}