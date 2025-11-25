using Microsoft.Extensions.DependencyInjection;
using SilentGuardianX.Services;
using SilentGuardianX.ViewModels.Components;
using SilentGuardianX.ViewModels;

namespace SilentGuardianX.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddTransient<MainViewModel>();
        collection.AddTransient<MenuViewModel>();
        collection.AddSingleton<MediatorService>();
    }
}