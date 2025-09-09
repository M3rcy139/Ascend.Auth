using Ascend.Auth.Domain.Models;

namespace Ascend.Auth.DataAccess.DataProviders;

public static class CountryDataProvider
{
    public static List<Country> GetCountries()
    {
        return
        [
            new () { Id = 1, Name = "Unknown"},
            new () { Id = 2, Name = "Russia" },
            new () { Id = 3, Name = "United States" },
            new () { Id = 4, Name = "Germany" },
            new () { Id = 5, Name = "France" },
            new () { Id = 6, Name = "United Kingdom" },
            new () { Id = 7, Name = "Chine" },
            new () { Id = 8, Name = "Japan" },
            new () { Id = 9, Name = "India" },
            new () { Id = 10, Name = "Canada" },
            new () { Id = 11, Name = "Brazil" },
        ];
    }
}