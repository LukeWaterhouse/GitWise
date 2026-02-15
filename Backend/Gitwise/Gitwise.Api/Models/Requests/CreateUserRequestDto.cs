using Gitwise.Api.Models.Requests.Enums;

namespace Gitwise.Api.Models.Requests;

public record CreateUserRequestDto(string EmailAddress, Guid TenantId, RoleDto Role);
