using UiService.Application.Interfaces;
using UiService.Domain.Interfaces.External;
using UiService.Domain.Models;

namespace UiService.Application.Services;

public class AccountService(
    IExternalRegistrationService externalRegistrationService,
    IExternalDatabaseService externalDatabaseService) : IAccountService
{
    public async Task<string> CreateAccountAsync(string emailAddress, string tenantId, Role role)
    {
        var externalUserId = await externalRegistrationService.RegisterUserAndGetIdAsync(emailAddress);
        await externalDatabaseService.CreateUserAsync(emailAddress, externalUserId, tenantId, role);
        
        return externalUserId;
    }
}