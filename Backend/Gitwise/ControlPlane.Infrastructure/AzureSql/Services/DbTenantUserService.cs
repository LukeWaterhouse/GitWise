using ControlPlane.Infrastructure.AzureSql.EfCore;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;
using ControlPlane.Infrastructure.AzureSql.Exceptions;
using ControlPlane.Infrastructure.AzureSql.Exceptions.Enums;
using ControlPlane.Infrastructure.AzureSql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.Services;

public class DbTenantUserService(IDbContextFactory<GitwiseContext> dbContextFactory) : IDbTenantUserService
{
    public async Task CreateTenantIfNotExistsAsync(string tenantName)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        var exists = await dbContext.Tenants
            .AnyAsync(t => t.Name == tenantName);

        if (exists)
            throw new DuplicateRecordException(RecordType.Tenant, tenantName);

        var tenant = new Tenant { Name = tenantName };
        dbContext.Tenants.Add(tenant);

        await dbContext.SaveChangesAsync();
    }

    public async Task CreateUserIfNotExistsAsync(Guid tenantId, string userEmail, string azureAdObjectId, Role role = Role.User)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync();
        
        var tenant = await dbContext.Tenants
            .FirstOrDefaultAsync(t => t.Id == tenantId);
        
        if (tenant == null)
            throw new RecordNotFoundException(RecordType.Tenant, tenantId.ToString());

        var exists = await dbContext.Users
            .AnyAsync(u => u.TenantId == tenant.Id && u.Email == userEmail);
        
        if (exists)
            throw new DuplicateRecordException(RecordType.User, userEmail);

        var user = new User()
        {
            Email = userEmail,
            TenantId = tenant.Id,
            Tenant = tenant,
            Role = role,
            AzureObjectId = azureAdObjectId
        };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
    }
}