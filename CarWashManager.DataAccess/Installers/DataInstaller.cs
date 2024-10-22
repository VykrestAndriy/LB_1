using Microsoft.Extensions.DependencyInjection;
using CarWashManager.DataAccess.Repositories.Order;

namespace CarWashManager.DataAccess.Installers;

public static class DataInstaller
{
    public static IServiceCollection AddDataContext(this IServiceCollection services)
    {
        services
            .AddSingleton<WashContext>()
            .AddTransient<ITransactionRepository, TransactionRepository>()
            .AddTransient<IWashRepository, WashRepository>();

        return services;
    }
}