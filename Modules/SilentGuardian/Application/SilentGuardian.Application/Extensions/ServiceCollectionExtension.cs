using Microsoft.Extensions.DependencyInjection;

namespace SilentGuardian.Application.Extensions;

public static class ServiceCollectionExtension
{
 public static IServiceCollection AddSilentGuardianApplication(this IServiceCollection services)
 {
     services.AddMediator();
     return services;
 }
}