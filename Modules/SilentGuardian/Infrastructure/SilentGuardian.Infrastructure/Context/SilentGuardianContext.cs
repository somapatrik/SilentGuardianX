using Microsoft.EntityFrameworkCore;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Infrastructure.Context;

public class SilentGuardianContext : DbContext
{
    public DbSet<EndpointGroup> EndpointGroups { get; set; }
    public SilentGuardianContext(DbContextOptions<SilentGuardianContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}