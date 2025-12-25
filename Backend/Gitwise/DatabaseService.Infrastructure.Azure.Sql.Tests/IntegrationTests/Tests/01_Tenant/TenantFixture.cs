using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._01_Tenant;

public class TenantFixture : IDisposable
{
    public Services.DbTenantUserService DbTenantUserService { get; private set; }
    public PooledDbContextFactory<GitwiseContext> ContextFactory { get; private set; }
    
    public TenantFixture()
    {
        var options = new DbContextOptionsBuilder<GitwiseContext>()
            .UseSqlServer(ConnectionStrings.TestDbConnectionString)
            .Options;

        ContextFactory = new PooledDbContextFactory<GitwiseContext>(options);
        DbTenantUserService = new Services.DbTenantUserService(ContextFactory);
        
        var context = ContextFactory.CreateDbContext();
        context.Database.EnsureDeletedAsync().Wait();
        context.Database.EnsureCreatedAsync().Wait();
    }
    
    public void Dispose()
    {
        var context = ContextFactory.CreateDbContext();
        context.Database.EnsureDeletedAsync().Wait();
    }
}