using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Domain.Models.Enums;
using Gitwise.Api.Mapping;
using Gitwise.Api.Models.Requests;
using Gitwise.Api.Models.Requests.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Gitwise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestDto request, CancellationToken ct)
    {
        var user = await userService.CreateUserAsync(request.EmailAddress, request.TenantId, (Role)request.Role, ct);

        return Ok(user.FromDomain());
    }

    [HttpGet("tenant/{tenantId}")]
    public async Task<IActionResult> GetUsersByTenantAsync(Guid tenantId, CancellationToken ct)
    {
        var users = await userService.GetUsersByTenantIdAsync(tenantId, ct);
        return Ok(users.Select(u => u.FromDomain()));
    }
}