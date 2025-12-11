using UiService.Domain.Models;

namespace UiService.Domain.Interfaces.External;

public interface IExternalDatabaseService
{
    public Task CreateUserAsync(string email, string externalId, string tenantId, Role role);
}