using Ascend.Auth.Domain.Enums;
using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.Business.Interfaces;

public interface IUserFactory
{
    User CreateUser(string userName, string email, byte[] hashedPassword, UserStatus status);
    ContactDetail CreateContactDetail(Guid contactDetailId, string? backupEmail, string? phoneNumber, 
        int countryId);
}