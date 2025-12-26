using ControlPlane.Domain.Models;
using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Application.Interfaces.External.Repository;

public interface ITenantUserRepositoryService
{
    Task<User> CreateUserAsync(string emailAddress, string externalUserId, Guid tenantId, Role role, CancellationToken ct);
    
    public Task<Tenant> CreateTenantAsync(string name, CancellationToken ct);
}