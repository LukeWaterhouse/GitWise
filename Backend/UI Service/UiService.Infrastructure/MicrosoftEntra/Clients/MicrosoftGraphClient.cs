using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using UiService.Infrastructure.MicrosoftEntra.Interfaces;

namespace UiService.Infrastructure.MicrosoftEntra.Clients;

public class MicrosoftGraphClient(GraphServiceClient client, IConfiguration configuration) : IMicrosoftGraphClient
{
    
    private readonly string _issuerDomain = configuration["AzureAd:IssuerDomain"] ?? throw new ArgumentNullException("IssuerDomain");
    
    public async Task<string> CreateUserAndGetIdAsync(string emailAddress)
    {
        var user = new User
        {
            Identities = new List<ObjectIdentity>
            {
                new ObjectIdentity
                {
                    SignInType = "emailAddress",
                    Issuer = _issuerDomain,
                    IssuerAssignedId = emailAddress
                }
            },
            PasswordProfile = new PasswordProfile
            {
                Password = GenerateStrongPassword(),
                ForceChangePasswordNextSignIn = true
            }
        };

        var result = await client.Users.PostAsync(user);

        return result.Id;
    }

    private static string GenerateStrongPassword()
    {
        return $"Gtw-{Guid.NewGuid():N}!1A";
    }
}