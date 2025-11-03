using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Helpers;

public static class TestHelpers
{
    public static async Task CreateTenantAsync(string tenantName, GitwiseContext context)
    {
        var tenant = new Tenant() { Name = tenantName };
        
        context.Tenants.Add(tenant);
        await context.SaveChangesAsync();
    }
}