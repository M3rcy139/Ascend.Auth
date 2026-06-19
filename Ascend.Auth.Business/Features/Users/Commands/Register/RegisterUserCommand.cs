using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Constants.Messages;
using Ascend.Auth.Domain.Enums;
using Ascend.Common.Utils.Extensions;
using Ascend.Person.Client.Interfaces;
using Ascend.Person.Client.Models.Person;
using MediatR;

namespace Ascend.Auth.Business.Features.Users.Commands.Register;

public record RegisterUserCommand(string UserName, string Email, string Password) : ICommand;

public class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IUserFactory userFactory,
    IPersonClientService personClient)
    : IRequestHandler<RegisterUserCommand, Unit>
{
    public async Task<Unit> Handle(RegisterUserCommand command, CancellationToken ct)
    {
        var userNameExists = await userRepository.UserNameExistsAsync(command.UserName);
        userNameExists.ThrowIfTrue(() => new InvalidOperationException(ErrorMessages.AlreadyExistsUserName));

        var emailExists = await userRepository.UserEmailExistsAsync(command.Email);
        emailExists.ThrowIfTrue(() => new InvalidOperationException(ErrorMessages.AlreadyExistsEmail));

        var hashedPassword = passwordHasher.Generate(command.Password);
        var user = userFactory.CreateUser(command.UserName, command.Email, hashedPassword, UserStatus.Inactive);

        await userRepository.AddAsync(user);

        await personClient.CreatePerson(new CreatePersonDto
        {
            UserId = user.Id.ToString(),
            PersonId = user.PersonId.ToString(),
            UserName = user.Username,
            Email = user.Email
        });

        return Unit.Value;
    }
}

