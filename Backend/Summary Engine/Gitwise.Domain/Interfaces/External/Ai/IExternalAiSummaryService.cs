using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External.Ai;

public interface IExternalAiSummaryService
{
    public Task<string> GetAiGeneratedSummaryAsync(
        Dictionary<string, List<Commit>> repositoryCommits, 
        CancellationToken ct);
}