namespace Ascend.AuthService.Domain.Models;

public class ContactDetail: BaseModel
{
    public string? BackupEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}