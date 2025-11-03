namespace DatabaseService.Infrastructure.Azure.Sql.Interfaces;

public interface IDbTenantUserService
{
    public Task CreateTenantIfNotExistsAsync(string tenantName);
    
    public Task CreateUserIfNotExistsAsync(string tenantName, string userName, string userEmail);
}