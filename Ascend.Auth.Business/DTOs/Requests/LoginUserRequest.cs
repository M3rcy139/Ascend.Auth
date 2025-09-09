using System.ComponentModel.DataAnnotations;

namespace Ascend.Auth.Business.DTOs.Requests;

public class LoginUserRequest
{
    [MaxLength(50)]
    public required string Email { get; set; }
    public required string Password { get; set; }
}