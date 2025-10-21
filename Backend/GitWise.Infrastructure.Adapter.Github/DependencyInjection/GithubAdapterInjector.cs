using System.Net.Http.Headers;
using GitWise.Adapter.Github.Clients;
using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Services;
using Gitwise.Domain.Interfaces.External;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GitWise.Adapter.Github.DependencyInjection;

public static class GithubAdapterInjector
{
    public static IServiceCollection AddGithubAdapterServices(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["Github:BaseUrl"];
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            throw new InvalidOperationException("Github:BaseUrl is not configured.");
        }

        services.AddHttpClient<IGithubClient, GithubClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("MyApp", "1.0"));
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {configuration["Github:BearerToken"]}");
        });        
        
        services.AddScoped<IExternalRepositoryService, GithubRepositoryService>();
        services.AddScoped<IExternalCommitService, GithubCommitService>();
        
        return services;
    }
}