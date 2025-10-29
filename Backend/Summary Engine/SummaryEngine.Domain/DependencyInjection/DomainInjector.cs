using Microsoft.Extensions.DependencyInjection;
using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Domain.Services;

namespace SummaryEngine.Domain.DependencyInjection;

public static class DomainInjector
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryService, RepositoryService>();
        services.AddScoped<ICommitService, CommitService>();
        services.AddScoped<IWorkSummaryService, WorkSummaryService>();
        services.AddScoped<IFileChangeFilterService, FileChangeFilterService>();

        return services;
    }
    
}