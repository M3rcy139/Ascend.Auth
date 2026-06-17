using Ascend.Auth.Domain.Enums;
using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ascend.Auth.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        
        builder.Property(p => p.Status).IsRequired();

        builder
            .Property(p => p.Status)
            .HasConversion(new EnumToStringConverter<UserStatus>());

        builder
            .Property(u => u.Username)
            .IsRequired();
        
        builder
            .Property(u => u.Email)
            .IsRequired();
        
        builder.HasIndex(u => u.Email).IsUnique();
        
        builder
            .Property(u => u.PasswordHash)
            .IsRequired();

        builder
            .HasOne(u => u.ContactDetail)
            .WithOne()
            .HasForeignKey<User>(u => u.ContactDetailId);
    }
}