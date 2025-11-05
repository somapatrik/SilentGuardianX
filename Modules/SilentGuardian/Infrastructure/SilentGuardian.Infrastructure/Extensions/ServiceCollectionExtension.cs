using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SilentGuardian.Infrastructure.Context;

namespace SilentGuardian.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddSilentGuardianInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SilentGuardianContext>(options => options.UseSqlite(connectionString));
        //services.AddScoped<IArticleRepository, ArticleRepository>();
        return services;
    }
}