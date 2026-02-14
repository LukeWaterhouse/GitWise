using Azure.Identity;
using ControlPlane.Application.Interfaces.External;
using ControlPlane.Infrastructure.MicrosoftEntra.Clients;
using ControlPlane.Infrastructure.MicrosoftEntra.Interfaces;
using ControlPlane.Infrastructure.MicrosoftEntra.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph;

namespace ControlPlane.Infrastructure.MicrosoftEntra.DependencyInjection;

public static class MicrosoftEntraInjector
{
    public static IServiceCollection AddMicrosoftEntraServices(this IServiceCollection services, IConfiguration config)
    {
        var tenantId = config["AzureAd:TenantId"];
        var clientId = config["AzureAd:ClientId"];
        var clientSecret = config["AzureAd:ClientSecret"];

        var credential = new ClientSecretCredential(
            tenantId,
            clientId,
            clientSecret);

        var graphServiceClient = new GraphServiceClient(
            credential,
            ["https://graph.microsoft.com/.default"]);
        
        services.AddSingleton(graphServiceClient);
        
        services.AddScoped<IMicrosoftGraphClient, MicrosoftGraphClient>();
        services.AddScoped<IExternalRegistrationService, EntraRegistrationService>();
        
        return services;
    }
}