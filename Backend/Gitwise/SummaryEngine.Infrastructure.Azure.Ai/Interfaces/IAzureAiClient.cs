namespace SummaryEngine.Infrastructure.Azure.Ai.Interfaces;

public interface IAzureAiClient
{
    public Task<string> GetMessageResponseAsync(string message, CancellationToken ct);
}
