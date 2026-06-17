using Ascend.Auth.Business.Abstractions;
using Ascend.Auth.DataAccess.Interfaces;
using Ascend.Auth.Domain.Constants.Messages;
using Ascend.Auth.Domain.Enums;
using Ascend.Auth.Domain.Extensions;
using MediatR;

namespace Ascend.Auth.Business.Features.Users.Commands.AssignRole;

public record AssignRoleCommand(Guid UserId, UserRole Role) : ICommand;

public class AssignRoleCommandHandler(IUserRepository userRepository)
    : IRequestHandler<AssignRoleCommand, Unit>
{
    public async Task<Unit> Handle(AssignRoleCommand command, CancellationToken ct)
    {
        var user = await userRepository.GetUserByIdAsync(command.UserId);
        user.ValidateEntity(ErrorMessages.UserNotFound);

        var roleName = command.Role.ToString();

        if (user!.Roles.Contains(roleName))
            throw new InvalidOperationException(ErrorMessages.RoleAlreadyAssigned);

        user.Roles = [..user.Roles, roleName];

        return Unit.Value;
    }
}
