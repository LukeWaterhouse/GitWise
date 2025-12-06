using UiService.Middleware;

namespace UiService.DependencyInjection;

public static class PresentationInjector
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        return services;
    }
}