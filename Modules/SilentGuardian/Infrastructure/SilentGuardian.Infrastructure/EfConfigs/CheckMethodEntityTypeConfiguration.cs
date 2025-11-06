using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilentGuardian.Domain.Checks;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Infrastructure.EfConfigs;

public class CheckMethodEntityTypeConfiguration : IEntityTypeConfiguration<CheckMethod>
{
    public void Configure(EntityTypeBuilder<CheckMethod> builder)
    {
        // základní tabulka pro abstraktní třídu
        builder.ToTable("CheckMethods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.LastResult)
            .IsRequired();

        builder.Property(x => x.LastCheck)
            .IsRequired();

        builder.Property(x => x.TimeoutLimit)
            .IsRequired();

        builder.Property(x => x.Timeout)
            .IsRequired();
        
        builder.HasOne(e=>e.Endpoint)                // CheckMethod patří k jednomu Endpoint
            .WithMany(e => e.CheckMethods)     // Endpoint má mnoho CheckMethods
            .HasForeignKey(e => e.EndpointId)       // FK v CheckMethods → Endpoint.Id
            .OnDelete(DeleteBehavior.Cascade);
    }
}