using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend.Auth.DataAccess.Configurations;

public class ContactDetailConfiguration: IEntityTypeConfiguration<ContactDetail>
{
    public void Configure(EntityTypeBuilder<ContactDetail> builder)
    {
        builder.HasKey(cd => cd.Id);
        
        builder
            .HasOne(cd => cd.Country)
            .WithMany()
            .HasForeignKey(cd => cd.CountryId);
    }
}