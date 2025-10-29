namespace SummaryEngine.Infrastructure.Ai.Azure.Interfaces;

public interface IAzureAiClient
{
    public Task<string> GetMessageResponseAsync(string message, CancellationToken ct);
}
