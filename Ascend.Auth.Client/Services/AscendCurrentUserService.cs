using Ascend.Auth.Common.Interfaces;
using Ascend.Common.Identity;
using Ascend.Common.Identity.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Ascend.Auth.Client.Services;

public class AscendCurrentUserService : AscendCurrentUserService<ICurrentUser>, ICurrentUserService
{
    public AscendCurrentUserService(IHttpContextAccessor contextAccessor, IOptionsMonitor<JwtBearerOptions> options,
        IAuthenticationSchemeProvider schemes, ICurrentUserFactory<ICurrentUser> currentUserFactory) : base(
        contextAccessor, options, schemes, currentUserFactory)
    {
    }
}
