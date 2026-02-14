using ControlPlane.Application.DependencyInjection;
using ControlPlane.Infrastructure.AzureServiceBus.DependencyInjection;
using ControlPlane.Infrastructure.AzureSql.DependencyInjection;
using ControlPlane.Infrastructure.MicrosoftEntra.DependencyInjection;

namespace Gitwise.Api.DependencyInjection.Modules;

public static class ControlPlaneInjector
{
    public static IServiceCollection AddControlPlaneServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddApplicationServices()
            .AddAzureSqlServices(config)
            .AddAzureServiceBusServices(config)
            .AddMicrosoftEntraServices(config);

        return services;
    }
}