using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Domain.Models.Enums;
using Gitwise.Api.Models.Requests.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Gitwise.Api.Controllers;

public class UserController(IUserService userService) : ControllerBase
{
    public async Task<IActionResult> CreateUserAsync(string emailAddress, Guid tenantId, RoleDto role, CancellationToken ct)
    {
        var user = await userService.CreateUserAsync(emailAddress, tenantId, (Role)role, ct);
        
        return Ok(user);
    }
}