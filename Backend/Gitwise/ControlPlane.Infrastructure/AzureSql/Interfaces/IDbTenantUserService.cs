using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;

namespace ControlPlane.Infrastructure.AzureSql.Interfaces;

public interface IDbTenantUserService
{
    public Task CreateTenantIfNotExistsAsync(string tenantName);
    
    public Task CreateUserIfNotExistsAsync(Guid tenantId, string userEmail, string azureAdObjectId, Role role = Role.User);
}