namespace Ascend.Auth.Domain.Models;

public class RefreshToken : BaseModel
{
    public required string Token { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreatedAt { get; set; }
}
