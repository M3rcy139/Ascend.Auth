using System.ComponentModel.DataAnnotations;

namespace Ascend.Auth.Business.DTOs.Requests;

public class RegisterUserRequest
{
    public required string UserName { get; set; }
    [MaxLength(50)]
    public required string Email { get; set; }
    public required string Password { get; set; }
}