using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SilentGuardian.Domain.Repositories;
using SilentGuardian.Infrastructure.Context;
using SilentGuardian.Infrastructure.Repositories;

namespace SilentGuardian.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSilentGuardianInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SilentGuardianContext>(options => options.UseSqlite(connectionString));
        services.AddScoped<IEndpointGroupRepository, EndpointGroupRepository>();
        
        // Po vytvoření ServiceProvideru se databáze automaticky vytvoří
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<SilentGuardianContext>();
            db.Database.EnsureCreated();
        }
        
        return services;
    }
}