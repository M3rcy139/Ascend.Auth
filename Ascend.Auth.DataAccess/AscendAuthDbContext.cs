using Ascend.Auth.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.DataAccess;

public class AscendAuthDbContext : DbContext
{
    public AscendAuthDbContext(DbContextOptions<AscendAuthDbContext> options) : base(options)
    {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<ContactDetail> ContactDetails { get; set; }
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AscendAuthDbContext).Assembly);
    }
}