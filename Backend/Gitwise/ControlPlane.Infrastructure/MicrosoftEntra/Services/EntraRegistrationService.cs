using ControlPlane.Application.Interfaces.External;
using ControlPlane.Infrastructure.MicrosoftEntra.Interfaces;

namespace ControlPlane.Infrastructure.MicrosoftEntra.Services;

public class EntraRegistrationService(IMicrosoftGraphClient microsoftGraphClient) : IExternalRegistrationService
{
    public async Task<string> RegisterUserAndGetIdAsync(string emailAddress)
    {
        var userId = await microsoftGraphClient.CreateUserAndGetIdAsync(emailAddress);
        return userId;
    }
}