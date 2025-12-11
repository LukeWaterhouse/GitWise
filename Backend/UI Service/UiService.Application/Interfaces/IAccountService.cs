using UiService.Domain.Models;

namespace UiService.Application.Interfaces;

public interface IAccountService
{
    Task<string> CreateAccountAsync(string emailAddress, string tenantId, Role role);
}