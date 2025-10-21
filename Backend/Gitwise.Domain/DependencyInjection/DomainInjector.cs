using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Gitwise.Domain.DependencyInjection;

public static class DomainInjector
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryService, RepositoryService>();
        services.AddScoped<ICommitService, CommitService>();

        return services;
    }
    
}