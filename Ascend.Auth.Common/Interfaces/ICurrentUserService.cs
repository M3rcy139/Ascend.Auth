using Ascend.Common.Identity.Abstractions;

namespace Ascend.Auth.Common.Interfaces;

public interface ICurrentUserService : ICurrentUserService<ICurrentUser>
{
}

public interface ICurrentUser : IIdentityUser
{
    Guid Id { get; }
    string UserName { get; }
    string Email { get; }
    Guid PersonId { get; }
    string[] Roles { get; }
}

public record CurrentUser(Guid Id, string UserName, string Email, Guid PersonId, string[] Roles) : ICurrentUser
{
    public static CurrentUser Create(Guid id, string userName, string email, Guid personId, string[] roles)
        => new(id, userName, email, personId, roles);

    public static CurrentUser Empty() =>
        new(Guid.Empty,
            string.Empty,
            string.Empty,
            Guid.Empty,
            Array.Empty<string>());
}