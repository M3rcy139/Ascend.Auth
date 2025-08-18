using Ascend.Auth.DataAccess.DataProviders;
using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ascend.Auth.DataAccess.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(cd => cd.Id);
        
        builder.Property(cd => cd.Name).IsRequired();
        
        builder.HasData(CountryDataProvider.GetCountries());
    }
}