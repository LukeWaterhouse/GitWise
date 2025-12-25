using DatabaseService.Infrastructure.Azure.Sql.Exceptions;
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
        await fixture.DbTenantUserService.CreateTenantIfNotExistsAsync(tenantName);
        
        // Assert
        var context = await fixture.ContextFactory.CreateDbContextAsync();
        
        var tenantExists = await context.Tenants.AnyAsync(t => t.Name == tenantName);
        tenantExists.ShouldBe(true);
    }
    
    [Fact, Order(2)]
    public async Task CreateTenant_AlreadyExists_ShouldThrowException()
    {
        // Arrange
        const string tenantName = "TestTenant";
    
        // Act
        DuplicateRecordException? ex = null;
        try
        {
            await fixture.DbTenantUserService.CreateTenantIfNotExistsAsync(tenantName);
        }
        catch (DuplicateRecordException e)
        {
            ex = e;
        }

        // Assert
        ex.ShouldNotBeNull();
        ex.ShouldBeOfType<DuplicateRecordException>();
        ex.Message.ShouldBe("Tenant with value 'TestTenant' already exists.");

        var context = await fixture.ContextFactory.CreateDbContextAsync();
        var tenantExists = await context.Tenants.AnyAsync(t => t.Name == tenantName);
        tenantExists.ShouldBe(true);
    }


}