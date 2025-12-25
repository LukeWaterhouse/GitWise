using DatabaseService.Infrastructure.Azure.Sql.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Xunit.Extensions.Ordering;

namespace DatabaseService.Infrastructure.Azure.Sql.IntegrationTests.IntegrationTests.Tests._02_User;


[Collection("User Collection"), Order(2)]
public class UserTests(UserFixture fixture)
{
    [Fact, Order(1)]
    public async Task CreateUser_ValidScenario_ShouldSucceed()
    {
        // Arrange
        var userName = "Luke Skywalker";
        var userEmail = "lukeskywalker@gmail.com";
        
        // Act
        await fixture.DbTenantUserService.CreateUserIfNotExistsAsync(fixture.ExistingTenantName, userName, userEmail);
        
        // Assert
        var context = await fixture.ContextFactory.CreateDbContextAsync();
        var userExists = await context.Users
            .AnyAsync(u => 
                u.Email == userEmail && 
                u.Tenant.Name == fixture.ExistingTenantName &&
                u.Name == userName);
        
        userExists.ShouldBe(true);
    }
    
    [Fact, Order(2)]
    public async Task CreateUser_EmailAlreadyExists_ShouldThrowException()
    {
        // Arrange
        var userName = "Luke Skywalker 2";
        var userEmail = "lukeskywalker@gmail.com";
        
        // Act
        DuplicateRecordException? ex = null;
        try
        {
            await fixture.DbTenantUserService.CreateUserIfNotExistsAsync(fixture.ExistingTenantName, userName, userEmail);
        }
        catch (DuplicateRecordException e)
        {
            ex = e;
        }
        
        // Assert
        ex.ShouldNotBeNull();
        ex.ShouldBeOfType<DuplicateRecordException>();
        ex.Message.ShouldBe("User with value 'lukeskywalker@gmail.com' already exists.");

        var context = await fixture.ContextFactory.CreateDbContextAsync();
        var userExists = await context.Users.AnyAsync(u => u.Email == userEmail );
        userExists.ShouldBe(true);
    }
    
    [Fact, Order(3)]
    public async Task CreateUser_NonExistingTenant_ShouldThrowException()
    {
        // Arrange
        var userName = "Han Solo";
        var userEmail = "hansolo@gmail.com";
        
        // Act
        RecordNotFoundException? ex = null;
        try
        {
            await fixture.DbTenantUserService.CreateUserIfNotExistsAsync("Missing Tenant", userName, userEmail);
        }
        catch (RecordNotFoundException e)
        {
            ex = e;
        }
        
        // Assert
        ex.ShouldNotBeNull();
        ex.ShouldBeOfType<RecordNotFoundException>();
        ex.Message.ShouldBe("Tenant with value 'Missing Tenant' not found.");

        var context = await fixture.ContextFactory.CreateDbContextAsync();
        var userExists = await context.Users.AnyAsync(u => u.Email == userEmail );
        userExists.ShouldBe(false);
    }
}