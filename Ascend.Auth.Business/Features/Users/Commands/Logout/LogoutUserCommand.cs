using Ascend.Auth.DataAccess.Interfaces;
using MediatR;

namespace Ascend.Auth.Business.Features.Users.Commands.Logout;

public record LogoutUserCommand(string RefreshToken) : ICommand;

public class LogoutUserCommandHandler(IRefreshTokenRepository refreshTokenRepository)
    : IRequestHandler<LogoutUserCommand, Unit>
{
    public async Task<Unit> Handle(LogoutUserCommand command, CancellationToken ct)
    {
        var stored = await refreshTokenRepository.GetByTokenAsync(command.RefreshToken);

        if (stored != null && !stored.IsRevoked)
            stored.IsRevoked = true;

        return Unit.Value;
    }
}
