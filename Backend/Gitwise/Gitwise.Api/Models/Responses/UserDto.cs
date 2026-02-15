using Gitwise.Api.Models.Requests.Enums;

namespace Gitwise.Api.Models.Responses;

public record UserDto(
    Guid Id,
    Guid TenantId,
    string Email,
    RoleDto Role,
    string ExternalId
);
