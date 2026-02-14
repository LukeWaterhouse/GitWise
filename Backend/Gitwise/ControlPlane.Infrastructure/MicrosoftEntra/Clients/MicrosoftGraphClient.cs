using ControlPlane.Infrastructure.MicrosoftEntra.Interfaces;
using ControlPlane.Infrastructure.MicrosoftEntra.Exceptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Models.ODataErrors;

namespace ControlPlane.Infrastructure.MicrosoftEntra.Clients;

public class MicrosoftGraphClient(GraphServiceClient client, IConfiguration configuration) : IMicrosoftGraphClient
{
    private readonly string _issuerDomain = configuration["Azure:AzureAd:IssuerDomain"] ?? throw new ArgumentNullException("IssuerDomain");
    
    public async Task<string> CreateUserAndGetIdAsync(string emailAddress)
    {
        var user = new User
        {
            DisplayName = emailAddress.Split('@')[0],
            Identities =
            [
                new ObjectIdentity
                {
                    SignInType = "emailAddress",
                    Issuer = _issuerDomain,
                    IssuerAssignedId = emailAddress
                }
            ],
            PasswordProfile = new PasswordProfile
            {
                Password = GenerateStrongPassword(),
                ForceChangePasswordNextSignIn = true
            }
        };

        try
        {
            var result = await client.Users.PostAsync(user);
            return result?.Id ?? throw new InvalidOperationException("User creation failed - no ID returned");
        }
        catch (ODataError ex) when (ex.Error?.Message?.Contains("Another object with the same value for property userPrincipalName already exists") == true)
        {
            throw new EntraUserExistsException();
        }
    }

    private static string GenerateStrongPassword()
    {
        return $"{Guid.NewGuid()}";
    }
}