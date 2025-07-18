using Ascend.AuthService.Business.DTOs.Requests;
using Ascend.AuthService.Business.Interfaces;
using Ascend.AuthService.Domain.Constants.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Ascend.AuthService.API.Controllers;

[ApiController]
[Route("api/users/")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        await _userService.Register(request);

        return Ok(new { message = string.Format(InfoMessages.SuccessfulRegistration) });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
    {
        var token = await _userService.Login(request);

        Response.Cookies.Append("token", token);

        return Ok(new { message = string.Format(InfoMessages.SuccessfulLogin) });
    }
}