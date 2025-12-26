namespace SummaryEngine.Infrastructure.Azure.AzureAi.Interfaces;

public interface IAzureAiClient
{
    public Task<string> GetMessageResponseAsync(string message, CancellationToken ct);
}
