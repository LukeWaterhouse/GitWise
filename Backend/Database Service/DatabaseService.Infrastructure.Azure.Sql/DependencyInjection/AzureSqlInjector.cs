using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseService.Infrastructure.Azure.Sql.DependencyInjection;

public static class AzureSqlInjector
{
    public static IServiceCollection AddAzureSqlServices(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlConnectionString = configuration.GetSection("Azure:Sql:ConnectionString").Value;

        services.AddDbContextFactory<GitwiseContext>(
            options => options.UseSqlServer(sqlConnectionString));
        
        services.AddScoped<IDatabaseService, Services.DatabaseService>();
        
        return services;
    }
}
