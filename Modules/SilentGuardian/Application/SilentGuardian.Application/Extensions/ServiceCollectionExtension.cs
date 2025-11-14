using Microsoft.Extensions.DependencyInjection;
using SilentGuardian.Application.Mappers;
using SilentGuardian.Application.Mappers.Interfaces;

namespace SilentGuardian.Application.Extensions;

public static class ServiceCollectionExtension
{
 public static IServiceCollection AddSilentGuardianApplication(this IServiceCollection services)
 {
     // Register requests and commands
     services.AddMediator();
     services.AddScoped<IAppMapper, AppMapper>();
     return services;
 }
}