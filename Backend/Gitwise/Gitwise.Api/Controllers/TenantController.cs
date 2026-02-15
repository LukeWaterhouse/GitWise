using ControlPlane.Application.Interfaces.Application;
using Gitwise.Api.Mapping;
using Gitwise.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Gitwise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TenantController(ITenantService tenantService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTenantAsync([FromBody] CreateTenantRequestDto request, CancellationToken ct)
    {
        var tenant = await tenantService.CreateTenantAsync(request.TenantName, ct);
        return Ok(tenant.FromDomain());
    }

    [HttpGet]
    public async Task<IActionResult> GetTenantsAsync(CancellationToken ct)
    {
        var tenants = await tenantService.GetTenantsAsync(ct);
        return Ok(tenants.Select(t => t.FromDomain()));        
    }
}