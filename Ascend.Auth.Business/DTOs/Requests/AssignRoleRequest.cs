using Ascend.Auth.Domain.Enums;

namespace Ascend.Auth.Business.DTOs.Requests;

public class AssignRoleRequest
{
    public required UserRole Role { get; set; }
}
