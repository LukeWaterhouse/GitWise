using Azure;
using Azure.AI.OpenAI;
using Gitwise.Domain.Interfaces.External.Ai;
using Gitwise.Infrastructure.Ai.Azure.Clients;
using Gitwise.Infrastructure.Ai.Azure.Interfaces;
using Gitwise.Infrastructure.Ai.Azure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Chat;

namespace Gitwise.Infrastructure.Ai.Azure.DependencyInjection;

public static class AzureAiInjector
{
    private const string AzureAiEndpointConfig = "Azure:Ai:Endpoint";
    private const string AzureAiApiKeyConfig = "Azure:Ai:ApiKey";
    private const string AzureAiDeploymentConfig = "Azure:Ai:DeploymentName";
    
    private const string ConfigUnconfiguredTemplate = "'{0}' is not configured.";

    public static IServiceCollection AddAzureAiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ChatClient>(_ =>
        {
            var endpoint = configuration[AzureAiEndpointConfig];
            var apiKey = configuration[AzureAiApiKeyConfig];
            var deploymentName = configuration[AzureAiDeploymentConfig];
            
            ValidateConfiguration(endpoint, AzureAiEndpointConfig);
            ValidateConfiguration(apiKey, AzureAiApiKeyConfig);
            ValidateConfiguration(deploymentName, AzureAiDeploymentConfig);

            var azureClient = new AzureOpenAIClient(new Uri(endpoint!), new AzureKeyCredential(apiKey!));
            var chatClient = azureClient.GetChatClient(deploymentName);

            return chatClient;
        });
        
        services.AddScoped<IAzureAiClient, AzureAiClient>();
        services.AddScoped<IExternalAiSummaryService, AzureAiSummaryService>();
        
        return services;
    }
    
    private static void ValidateConfiguration(string? value, string configLocation)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException(string.Format(ConfigUnconfiguredTemplate, configLocation));
        }
    }
}