using SummaryEngine.Adapter.Github.AzureAi.DependencyInjection;
using SummaryEngine.Adapter.Github.GithubAdapter.DependencyInjection;
using SummaryEngine.Domain.DependencyInjection;
using SummaryEngine.Adapter.Github.AzureSql.DependencyInjection;

namespace Gitwise.Api.DependencyInjection.Modules;

public static class SummaryEngineInjector
{
    public static IServiceCollection AddSummaryEngineServices(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddDomainServices()
            .AddGithubAdapterServices(config)
            .AddAzureAiServices(config)
            .AddAzureSqlServices(config);
        
        return services;
    }
}