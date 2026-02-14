using ControlPlane.Infrastructure.MicrosoftEntra.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace ControlPlane.Infrastructure.MicrosoftEntra.Clients;

public class MicrosoftGraphClient(GraphServiceClient client, IConfiguration configuration) : IMicrosoftGraphClient
{
    private readonly string _issuerDomain = configuration["Azure:AzureAd:IssuerDomain"] ?? throw new ArgumentNullException("IssuerDomain");
    
    public async Task<string> CreateUserAndGetIdAsync(string emailAddress)
    {
        var user = new User
        {
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

        var result = await client.Users.PostAsync(user);

        if (result == null)
        {
            throw new Exception("Failed to create user");
        }

        return result.Id;
    }

    private static string GenerateStrongPassword()
    {
        return $"{Guid.NewGuid()}";
    }
}