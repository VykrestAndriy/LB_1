﻿using CarWashManager.BusinessLogic.Contracts;
using Microsoft.Extensions.DependencyInjection;
using CarWashManager.BusinessLogic.Services;
using CarWashManager.DataAccess.Repositories.Order;

namespace CarWashManager.BusinessLogic.Installers;

public static class TransactionInstaller
{
    public static IServiceCollection AddTransactions(this IServiceCollection services)
    {
        services.AddScoped<ITransactionService, TransactionService>();
        return services;
    }
}