using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;
using DatabaseService.Infrastructure.Azure.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Infrastructure.Azure.Sql.Services;

public class DatabaseService(IDbContextFactory<GitwiseContext> dbContextFactory) : IDatabaseService
{
    public async Task<bool> CreateTenantIfNotExistsAsync(string tenantName)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        var exists = await dbContext.Tenants
            .AnyAsync(t => t.Name == tenantName);

        if (exists)
            return false;

        var tenant = new Tenant { Name = tenantName };
        dbContext.Tenants.Add(tenant);

        await dbContext.SaveChangesAsync();
        
        return true;
    }
}