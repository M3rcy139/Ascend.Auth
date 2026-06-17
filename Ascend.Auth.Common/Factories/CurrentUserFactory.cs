using System.Security.Claims;
using Ascend.Auth.Common.Interfaces;
using Ascend.Auth.Domain.Constants.Claims;
using Ascend.Common.Identity.Abstractions;

namespace Ascend.Auth.Common.Factories;

public class CurrentUserFactory : ICurrentUserFactory<CurrentUser>
{
    public CurrentUser CreateCurrentUser(IEnumerable<Claim>? claims)
    {
        return CreateFromClaims(claims);
    }

    private static CurrentUser CreateFromClaims(IEnumerable<Claim>? claims)
    {
        if (claims == null || !claims.Any())
            return CurrentUser.Empty();

        var idStr = claims.FirstOrDefault(c => c.Type == UserClaims.UserId)?.Value;
        if (!Guid.TryParse(idStr, out var userId))
            return CurrentUser.Empty();

        var userName = claims.FirstOrDefault(c => c.Type == UserClaims.Username)?.Value ?? string.Empty;

        var email = claims.FirstOrDefault(c => c.Type == UserClaims.Email)?.Value ?? string.Empty;
        
        var personIdStr = claims.FirstOrDefault(c => c.Type == UserClaims.PersonId)?.Value;
        var personId = Guid.TryParse(personIdStr, out var parsedPersonId) ? parsedPersonId : Guid.Empty;

        var roles = claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray() ?? Array.Empty<string>();

        return CurrentUser.Create(userId, userName, email, personId, roles);
    }
}