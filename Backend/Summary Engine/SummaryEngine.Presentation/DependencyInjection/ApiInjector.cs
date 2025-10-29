using SummaryEngine.Presentation.MessageQueue.Handlers;
using SummaryEngine.Presentation.Middleware;

namespace SummaryEngine.Presentation.DependencyInjection;

public static class ApiInjector
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddSingleton<ExceptionMiddleware>();
        services.AddSingleton<ServiceBusReceiverService>();

        return services;
    }
}