using Microsoft.Extensions.DependencyInjection;
using SilentGuardianX.ViewModels;

namespace SilentGuardianX.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        /*
        collection.AddSingleton<IRepository, Repository>();
        collection.AddTransient<BusinessService>();
        */
        collection.AddTransient<MainViewModel>();
    }
}