using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilentGuardian.Domain.Endpoints;

namespace SilentGuardian.Infrastructure.EfConfigs;

public class EndpointGroupEntityTypeConfiguration : IEntityTypeConfiguration<EndpointGroup>
{
    public void Configure(EntityTypeBuilder<EndpointGroup> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.GroupName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(200);

        builder.Property(e => e.IsEnabled)
            .IsRequired();

        builder.Property(e => e.Result)
            .IsRequired();

        // vztah 1:N s Endpoint
        builder.HasMany(e => e.Endpoints)
            .WithOne()
            .HasForeignKey("EndpointGroupId") // shadow FK
            .OnDelete(DeleteBehavior.Cascade);
    }
}