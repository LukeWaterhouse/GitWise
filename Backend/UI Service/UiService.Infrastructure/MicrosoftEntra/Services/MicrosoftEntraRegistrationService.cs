using UiService.Domain.Interfaces.External;
using UiService.Infrastructure.MicrosoftEntra.Interfaces;

namespace UiService.Infrastructure.MicrosoftEntra.Services;

public class MicrosoftEntraRegistrationService(IMicrosoftGraphClient microsoftGraphClient): IExternalRegistrationService
{
    public async Task<string> RegisterUserAndGetIdAsync(string emailAddress)
    {
        var userId = await microsoftGraphClient.CreateUserAndGetIdAsync(emailAddress);
        return userId;
    }
}