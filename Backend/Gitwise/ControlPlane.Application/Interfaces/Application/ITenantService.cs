using ControlPlane.Domain.Models;

namespace ControlPlane.Application.Interfaces.Application;

public interface ITenantService
{
    public Task<Tenant> CreateTenantAsync(string name, CancellationToken ct);
    
    public Task<List<Tenant>> GetTenantsAsync(CancellationToken ct);
    
    public Task DeleteTenantAsync(Guid tenantId, CancellationToken ct);
}