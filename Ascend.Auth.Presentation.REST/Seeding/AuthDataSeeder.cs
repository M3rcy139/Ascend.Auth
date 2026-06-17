using Ascend.Auth.Business.Interfaces;
using Ascend.Auth.Business.Interfaces.Authentication;
using Ascend.Auth.DataAccess;
using Ascend.Auth.Domain.Constants.Roles;
using Ascend.Auth.Domain.Enums;
using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.Presentation.REST.Seeding;

public class AuthDataSeeder : IDataSeeder
{
    public static readonly Guid AdminUserId = new("a0000000-0000-0000-0000-000000000001");
    public static readonly Guid AdminPersonId = new("a0000000-0000-0000-0000-000000000002");
    public static readonly Guid AdminContactId = new("a0000000-0000-0000-0000-000000000003");

    private readonly AscendAuthDbContext _context;
    private readonly IPasswordHasher _passwordHasher;

    public AuthDataSeeder(AscendAuthDbContext context, IPasswordHasher passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task SeedAsync()
    {
        if (await _context.Users.AnyAsync(u => u.Email == "admin@ascend.com"))
            return;

        var admin = new User
        {
            Id = AdminUserId,
            Username = "admin",
            Email = "admin@ascend.com",
            PasswordHash = _passwordHasher.Generate("Admin1234!"),
            Status = UserStatus.Active,
            Roles = [UserRoles.Admin, UserRoles.User],
            PersonId = AdminPersonId,
            ContactDetailId = AdminContactId,
            ContactDetail = new ContactDetail
            {
                Id = AdminContactId,
                CountryId = 1
            }
        };

        await _context.Users.AddAsync(admin);
        await _context.SaveChangesAsync();
    }
}
