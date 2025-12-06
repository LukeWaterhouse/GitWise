using ApiService.Middleware;

namespace ApiService.DependencyInjection;

public static class PresentationInjector
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}