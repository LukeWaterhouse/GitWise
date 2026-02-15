using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ControlPlane.Application.DependencyInjection;

public static class ApplicationInjector
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IWorkSummaryJobService, WorkSummaryJobService>();
        
        return services;
    }
    
}