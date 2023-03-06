﻿using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(x=> x.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        return services;
    }
}
