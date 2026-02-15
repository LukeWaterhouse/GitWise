using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Application.Interfaces.External;
using ControlPlane.Application.Interfaces.External.Repository;
using ControlPlane.Domain.Models;
using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Application.Services;

public class UserService(
    ITenantUserRepositoryService tenantUserRepositoryService,
    IExternalRegistrationService externalRegistrationService) : IUserService
{
    public async Task<User> CreateUserAsync(string emailAddress, Guid tenantId, Role role, CancellationToken ct)
    {
        var externalUserId = await externalRegistrationService.RegisterUserAndGetIdAsync(emailAddress);
        var user = await tenantUserRepositoryService.CreateUserAsync(emailAddress, externalUserId, tenantId, role, ct);

        return user;
    }

    public async Task<List<User>> GetUsersByTenantIdAsync(Guid tenantId, CancellationToken ct)
    {
        return await tenantUserRepositoryService.GetUsersByTenantIdAsync(tenantId, ct);
    }
}