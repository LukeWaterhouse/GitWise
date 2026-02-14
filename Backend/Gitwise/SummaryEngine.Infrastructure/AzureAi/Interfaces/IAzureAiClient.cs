namespace SummaryEngine.Adapter.Github.AzureAi.Interfaces;

public interface IAzureAiClient
{
    public Task<string> GetMessageResponseAsync(string message, CancellationToken ct);
}
