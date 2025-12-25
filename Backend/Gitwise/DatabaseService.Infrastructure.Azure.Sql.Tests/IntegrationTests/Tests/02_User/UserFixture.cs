using DatabaseService.Infrastructure.Azure.Sql.EfCore;
using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Constants;
using DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._02_User;

public class UserFixture : IDisposable
{
    public Services.DbTenantUserService DbTenantUserService { get; private set; }
    public PooledDbContextFactory<GitwiseContext> ContextFactory { get; private set; }
    
    public readonly string ExistingTenantName = "UserFixtureTestTenant";
    
    public UserFixture()
    {
        var options = new DbContextOptionsBuilder<GitwiseContext>()
            .UseSqlServer(ConnectionStrings.TestDbConnectionString)
            .Options;

        ContextFactory = new PooledDbContextFactory<GitwiseContext>(options);
        DbTenantUserService = new Services.DbTenantUserService(ContextFactory);
        
        var context = ContextFactory.CreateDbContext();
        context.Database.EnsureDeletedAsync().Wait();
        context.Database.EnsureCreatedAsync().Wait();

        TestHelpers.CreateTenantAsync(ExistingTenantName, context).Wait();
    }
    
    public void Dispose()
    {
        var context = ContextFactory.CreateDbContext();
        context.Database.EnsureDeletedAsync().Wait();
    }
}