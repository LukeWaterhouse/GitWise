namespace UiService.Infrastructure.MicrosoftEntra.Interfaces;

public interface IMicrosoftGraphClient
{
    public Task<string> CreateUserAndGetIdAsync(string emailAddress);
}