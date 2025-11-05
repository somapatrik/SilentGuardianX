using Microsoft.EntityFrameworkCore;

namespace SilentGuardian.Infrastructure.Context;

public class SilentGuardianContext : DbContext
{
    public SilentGuardianContext(DbContextOptions<SilentGuardianContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}