using ControlPlane.Infrastructure.AzureSql.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControlPlane.Infrastructure.AzureSql.DependencyInjection;

public static class AzureSqlInjector
{
    public static IServiceCollection AddAzureSqlServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnectionString = configuration.GetSection("Azure:Sql:ConnectionString").Value;

        services.AddDbContextFactory<ControlPlaneDbContext>(
            options => options.UseSqlServer(sqlConnectionString));
        
        
        return services;
    }
}
