using ControlPlane.Domain.Models;
using Gitwise.Api.Models.Requests.Enums;
using Gitwise.Api.Models.Responses;

namespace Gitwise.Api.Mapping;

public static class ControlPlaneMappingExtensions
{
    public static UserDto FromDomain(this User user)
    {
        return new UserDto(
            user.Id,
            user.TenantId,
            user.Email,
            (RoleDto)user.Role,
            user.ExternalId
        );
    }

    public static TenantDto FromDomain(this Tenant tenant)
    {
        return new TenantDto(
            tenant.Id,
            tenant.Name
        );
    }
}