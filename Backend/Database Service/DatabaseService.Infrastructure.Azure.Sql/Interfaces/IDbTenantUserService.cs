using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models.Enums;

namespace DatabaseService.Infrastructure.Azure.Sql.Interfaces;

public interface IDbTenantUserService
{
    public Task CreateTenantIfNotExistsAsync(string tenantName);
    
    public Task CreateUserIfNotExistsAsync(Guid tenantId, string userEmail, string azureAdObjectId, Role role = Role.User);
}