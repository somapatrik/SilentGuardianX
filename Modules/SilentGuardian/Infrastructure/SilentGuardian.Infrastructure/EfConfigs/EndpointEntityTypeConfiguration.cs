using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Infrastructure.EfConfigs;

public class EndpointEntityTypeConfiguration : IEntityTypeConfiguration<Endpoint>
{
    public void Configure(EntityTypeBuilder<Endpoint> builder)
    {
        builder.ToTable("Endpoints");
        
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(200);

        builder.Property(e => e.IpAddress)
            .IsRequired();

        builder.Property(e => e.IsEnabled)
            .IsRequired();

        builder.Property(e => e.Timeout)
            .IsRequired();

        builder.Property(e => e.Result)
            .IsRequired();

        // vztah 1:N s EndpointGroup
        builder.HasOne(e => e.EndpointGroup)
            .WithMany(g => g.Endpoints)
            .HasForeignKey(e => e.EndpointGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // CheckMethods: 1:N vztah (pokud existuje třída CheckMethod)
        builder.HasMany(e => e.CheckMethods)
            .WithOne()
            .HasForeignKey("EndpointId") // shadow FK
            .OnDelete(DeleteBehavior.Cascade);
    }
}