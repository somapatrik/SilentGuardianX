using Microsoft.EntityFrameworkCore;
using SilentGuardian.Domain.Checks;
using SilentGuardian.Domain.Endpoints;
using SilentGuardian.Infrastructure.EfConfigs;

namespace SilentGuardian.Infrastructure.Context;

public class SilentGuardianContext : DbContext
{
    public DbSet<EndpointGroup> EndpointGroups { get; set; }
    public DbSet<Endpoint> Endpoints { get; set; }
    public DbSet<CheckMethod> CheckMethods { get; set; }
    public DbSet<TcpPortCheck> TcpPortChecks { get; set; }
    public SilentGuardianContext(DbContextOptions<SilentGuardianContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new EndpointGroupEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EndpointEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new CheckMethodEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TcpPortCheckEntityTypeConfiguration());
    }
}