using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Domain.Models;

public class User(Guid id, Guid tenantId, string email, Role role, string externalId)
{
    public Guid Id { get; } = id;
    public Guid TenantId { get; } = tenantId;
    public string Email { get; } = email;
    public Role Role { get; set; } = role;
    public string ExternalId { get; } = externalId;
}