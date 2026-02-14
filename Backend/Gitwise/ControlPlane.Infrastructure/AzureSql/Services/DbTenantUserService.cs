using ControlPlane.Application.Exceptions;
using ControlPlane.Application.Exceptions.Enums;
using ControlPlane.Application.Interfaces.External.Repository;
using ControlPlane.Domain.Models;
using ControlPlane.Domain.Models.Enums;
using ControlPlane.Infrastructure.AzureSql.EfCore;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;
using ControlPlane.Infrastructure.AzureSql.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.Services;

public class DbTenantUserService(IDbContextFactory<ControlPlaneDbContext> dbContextFactory) : ITenantUserRepositoryService
{
    public async Task<User> CreateUserAsync(string emailAddress, string externalUserId, Guid tenantId, Role role, CancellationToken ct)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
        
        var tenant = await dbContext.Tenants
            .FirstOrDefaultAsync(t => t.Id == tenantId, ct);
        
        if (tenant == null)
                throw new RecordNotFoundException(RecordType.Tenant, tenantId.ToString());

        var exists = await dbContext.Users
            .AnyAsync(u => u.TenantId == tenant.Id && u.Email == emailAddress, ct);
        
        if (exists)
            throw new DuplicateRecordException(RecordType.User, emailAddress);

        var dbUser = new DbUser()
        {
            Email = emailAddress,
            TenantId = tenant.Id,
            DbTenant = tenant,
            DbRole = (DbRole)role,
            AzureObjectId = externalUserId
        };
        
        dbContext.Users.Add(dbUser);
        await dbContext.SaveChangesAsync(ct);

        return dbUser.ToDomain();
    }

    public async Task<Tenant> CreateTenantAsync(string name, CancellationToken ct)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
        
        var exists = await dbContext.Tenants
            .AnyAsync(t => t.Name == name, ct);

        if (exists)
            throw new DuplicateRecordException(RecordType.Tenant, name);

        var dbTenant = new DbTenant { Name = name };
        dbContext.Tenants.Add(dbTenant);

        await dbContext.SaveChangesAsync(ct);

        return dbTenant.ToDomain();
    }
}