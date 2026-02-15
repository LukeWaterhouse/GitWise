using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Application.Interfaces.External.Repository;
using ControlPlane.Domain.Models;

namespace ControlPlane.Application.Services;

public class TenantService(ITenantUserRepositoryService tenantUserRepositoryService) : ITenantService
{
    public async Task<Tenant> CreateTenantAsync(string name, CancellationToken ct)
    {
        var newTenant = await tenantUserRepositoryService.CreateTenantAsync(name, ct);
        return newTenant;
    }

    public async Task<List<Tenant>> GetTenantsAsync(CancellationToken ct)
    {
        var tenants = await tenantUserRepositoryService.GetTenants(ct);
        return tenants;
    }
}