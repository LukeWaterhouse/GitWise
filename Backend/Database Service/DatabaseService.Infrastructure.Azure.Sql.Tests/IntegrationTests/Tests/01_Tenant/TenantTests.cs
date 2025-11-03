using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Xunit.Extensions.Ordering;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._01_Tenant;

[Collection("Tenant Collection"), Order(1)]
public class TenantTests(TenantFixture fixture)
{
    
    [Fact, Order(1)]
    public async Task CreateTenant_ValidScenario_ShouldSucceed()
    {
        // Arrange
        var tenantName = "TestTenant";
        
        // Act
        var result = await fixture.DatabaseService.CreateTenantIfNotExistsAsync(tenantName);
        
        // Assert
        var context = await fixture.ContextFactory.CreateDbContextAsync();
        
        result.ShouldBe(true);
        var tenantExists = await context.Tenants.AnyAsync(t => t.Name == tenantName);
        tenantExists.ShouldBe(true);
    }
    
    [Fact, Order(2)]
    public async Task CreateTenant_AlreadyExists_ShouldFail()
    {
        // Arrange
        const string tenantName = "TestTenant";
        
        // Act
        var result = await fixture.DatabaseService.CreateTenantIfNotExistsAsync(tenantName);
        
        // Assert
        var context = await fixture.ContextFactory.CreateDbContextAsync();
        
        result.ShouldBe(false);
        var tenantExists = await context.Tenants.AnyAsync(t => t.Name == tenantName);
        tenantExists.ShouldBe(true);
    }
}