namespace UiService.Infrastructure.MicrosoftEntra.Models.Settings;

public class AzureAd
{
    public string TenantId { get; set; }
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string IssuerDomain { get; set; }
}