using GitWise.Api.Middleware;

namespace GitWise.Api.DependencyInjection;

public static class ApiInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}