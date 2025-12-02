using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;
using DatabaseService.Infrastructure.Azure.Sql.Exceptions;
using DatabaseService.Infrastructure.Azure.Sql.Exceptions.Enums;
using DatabaseService.Infrastructure.Azure.Sql.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseService.Infrastructure.Azure.Sql.Services;

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