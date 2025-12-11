namespace UiService.Domain.Interfaces.External;

public interface IExternalRegistrationService
{
    public Task<string> RegisterUserAndGetIdAsync(string emailAddress);
}