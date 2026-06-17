using Ascend.Auth.Business.DTOs.Requests;
using Ascend.Auth.Business.DTOs.Responses;
using Ascend.Auth.Business.Features.Users.Commands.AssignRole;
using Ascend.Auth.Business.Features.Users.Commands.Login;
using Ascend.Auth.Business.Features.Users.Commands.Logout;
using Ascend.Auth.Business.Features.Users.Commands.Refresh;
using Ascend.Auth.Business.Features.Users.Commands.Register;
using Ascend.Auth.Domain.Constants.Messages;
using Ascend.Auth.Domain.Constants.Roles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ascend.Auth.Presentation.REST.Controllers;

[ApiController]
[Route("api/users/")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken ct)
    {
        await sender.Send(new RegisterUserCommand(request.UserName, request.Email, request.Password), ct);
        return Ok(new { message = InfoMessages.SuccessfulRegistration });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request, CancellationToken ct)
    {
        var response = await sender.Send(new LoginUserCommand(request.Email, request.Password), ct);
        SetTokenCookies(response);
        return Ok(new { message = InfoMessages.SuccessfulLogin });
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(CancellationToken ct)
    {
        var refreshToken = Request.Cookies["refresh_token"];

        if (string.IsNullOrEmpty(refreshToken))
            return Unauthorized();

        var response = await sender.Send(new RefreshTokenCommand(refreshToken), ct);
        SetTokenCookies(response);
        return Ok(new { message = InfoMessages.SuccessfulRefresh });
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout(CancellationToken ct)
    {
        var refreshToken = Request.Cookies["refresh_token"];

        if (!string.IsNullOrEmpty(refreshToken))
            await sender.Send(new LogoutUserCommand(refreshToken), ct);

        Response.Cookies.Delete("access_token");
        Response.Cookies.Delete("refresh_token");

        return Ok(new { message = InfoMessages.SuccessfulLogout });
    }

    [Authorize(Roles = UserRoles.Admin)]
    [HttpPut("{userId:guid}/roles")]
    public async Task<IActionResult> AssignRole(Guid userId, [FromBody] AssignRoleRequest request, CancellationToken ct)
    {
        await sender.Send(new AssignRoleCommand(userId, request.Role), ct);
        return Ok(new { message = InfoMessages.RoleAssigned });
    }

    private void SetTokenCookies(AuthResponse response)
    {
        Response.Cookies.Append("access_token", response.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Secure = true,
            Expires = DateTimeOffset.UtcNow.AddHours(12)
        });

        Response.Cookies.Append("refresh_token", response.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Secure = true,
            Expires = response.RefreshTokenExpiresAt
        });
    }
}
