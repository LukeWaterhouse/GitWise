using ControlPlane.Domain.Models;
using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Application.Interfaces.Application;

public interface IUserService
{
    public Task<User> CreateUserAsync(string emailAddress, Guid tenantId, Role role, CancellationToken ct);
    
    public Task<List<User>> GetUsersByTenantIdAsync(Guid tenantId, CancellationToken ct);
}