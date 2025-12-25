using ControlPlane.Infrastructure.AzureSql.EfCore;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using ControlPlane.Infrastructure.AzureSql.Exceptions;
using ControlPlane.Infrastructure.AzureSql.Exceptions.Enums;
using ControlPlane.Infrastructure.AzureSql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.Services;

public class DbDeveloperService(IDbContextFactory<GitwiseContext> dbContextFactory) : IDbDeveloperService
{
    public async Task CreateDeveloperAsync(string name, string email, string tenantName)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        
        var tenant = await context.Tenants
            .FirstOrDefaultAsync(t => t.Name == tenantName);

        if (tenant is null)
        {
            throw new RecordNotFoundException(RecordType.Tenant, tenantName);
        }
        
        var developerExists = await context.Developers
            .AnyAsync(d => d.Email == email && d.TenantId == tenant.Id);

        if (developerExists)
        {
            throw new DuplicateRecordException(RecordType.Developer, email);
        }
        
        var developer = new Developer
        {
            Name = name,
            Email = email,
            TenantId = tenant.Id,
            Tenant = tenant
        };
        
        context.Developers.Add(developer);
        await context.SaveChangesAsync();
    }
}