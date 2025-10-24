using Gitwise.Domain.Interfaces.External.Ai;
using Gitwise.Domain.Models;
using Gitwise.Infrastructure.Ai.Azure.Interfaces;

namespace Gitwise.Infrastructure.Ai.Azure.Services;

public class AzureAiSummaryService(IAzureAiClient azureAiClient) : IExternalAiSummaryService
{
    public async Task<string> GetAiGeneratedSummaryAsync(Dictionary<string, List<Commit>> repositoryCommits, CancellationToken ct)
    {
        var response = await azureAiClient.GetMessageResponseAsync("Generate a summary", ct);
        return response;
    }
}