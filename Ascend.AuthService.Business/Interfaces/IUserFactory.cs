using Ascend.AuthService.Domain.Enums;
using Ascend.AuthService.Domain.Models;

namespace Ascend.AuthService.Business.Interfaces;

public interface IUserFactory
{
    User CreateUser(string userName, string email, byte[] hashedPassword, UserStatus status);
    ContactDetail CreateContactDetail(Guid contactDetailId, string? backupEmail, string? phoneNumber, 
        int countryId);
}