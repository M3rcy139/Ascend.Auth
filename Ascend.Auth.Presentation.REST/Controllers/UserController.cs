using Ascend.Auth.Business.DTOs.Requests;
using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Domain.Constants.Messages;
using Microsoft.AspNetCore.Mvc;

namespace Ascend.Auth.Presentation.REST.Controllers;

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

        return Ok(new {
            message = InfoMessages.SuccessfulLogin,
            token
        });
    }
}