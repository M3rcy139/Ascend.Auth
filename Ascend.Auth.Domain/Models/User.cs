using System.ComponentModel.DataAnnotations;
using Ascend.Auth.Domain.Enums;

namespace Ascend.Auth.Domain.Models;

public class User : BaseModel
{
    [MaxLength(50)]
    public required string Username { get; set; }
    [MaxLength(50)]
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    
    public UserStatus Status { get; set; }
    
    public Guid ContactDetailId { get; set; }
    public ContactDetail? ContactDetail { get; set; }
    
    public Guid PersonId { get; set; }
    public string[] Roles { get; set; }
}