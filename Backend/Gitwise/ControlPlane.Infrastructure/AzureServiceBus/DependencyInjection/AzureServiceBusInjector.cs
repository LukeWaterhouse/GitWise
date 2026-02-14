using ControlPlane.Application.Interfaces.External;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlPlane.Infrastructure.AzureServiceBus.DependencyInjection;

public static class AzureServiceBusInjector
{
    public static IServiceCollection AddAzureServiceBusServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IMessageService, AzureMessagePump>();
        
        return services;
    }
}