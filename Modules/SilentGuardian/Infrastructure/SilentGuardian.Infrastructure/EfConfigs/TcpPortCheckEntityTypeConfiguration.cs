using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilentGuardian.Domain.Checks;

namespace SilentGuardian.Infrastructure.EfConfigs;

public class TcpPortCheckEntityTypeConfiguration : IEntityTypeConfiguration<TcpPortCheck>
{
    public void Configure(EntityTypeBuilder<TcpPortCheck> builder)
    {
        builder.ToTable("TcpPortChecks");

        builder.Property(x => x.IP)
            .IsRequired();

        builder.Property(x => x.Port)
            .IsRequired();
    }
}