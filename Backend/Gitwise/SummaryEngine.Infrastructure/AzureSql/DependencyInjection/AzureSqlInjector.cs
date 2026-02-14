using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SummaryEngine.Adapter.Github.AzureSql.EfCore;

namespace SummaryEngine.Adapter.Github.AzureSql.DependencyInjection;

public static class AzureSqlInjector
{
    public static IServiceCollection AddAzureSqlServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnectionString = configuration.GetSection("Azure:Sql:ConnectionString").Value;

        services.AddDbContext<SummaryEngineDbContext>(
            options => options.UseSqlServer(sqlConnectionString));
        
        return services;
    }
}
