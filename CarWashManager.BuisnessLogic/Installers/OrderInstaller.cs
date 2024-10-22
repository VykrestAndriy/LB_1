using Microsoft.Extensions.DependencyInjection;
using CarWashManager.BusinessLogic.Contracts;
using CarWashManager.BusinessLogic.Services;

namespace CarWashManager.BusinessLogic.Installers;

public static class WashInstaller
{
    public static IServiceCollection AddOrders(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        return services;
    }
}