using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Domain.Enums;
using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.Business.Factories;

public class UserFactory : IUserFactory
{
    public User CreateUser(string userName, string email, byte[] hashedPassword, UserStatus status)
    {
        var contactDetailId = Guid.NewGuid();
        var personId = Guid.NewGuid();

        return new User
        {
            Id = Guid.NewGuid(),
            UserName = userName,
            Email = email,
            PasswordHash = hashedPassword,
            PersonId = personId,
            ContactDetailId = contactDetailId,
            Status = status,
            ContactDetail = CreateContactDetail(contactDetailId, null, null),
        };
    }

    public ContactDetail CreateContactDetail(Guid contactDetailId, string? backupEmail, string? phoneNumber,
        int countryId = 1)
    {
        return new ContactDetail
        {
            Id = contactDetailId,
            BackupEmail = backupEmail,
            PhoneNumber = phoneNumber,
            CountryId = countryId
        };
    }
}