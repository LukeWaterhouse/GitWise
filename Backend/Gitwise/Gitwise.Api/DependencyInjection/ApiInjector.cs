using Gitwise.Api.Middleware;

namespace Gitwise.Api.DependencyInjection;

public static class ApiInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();

        return services;
    }
}