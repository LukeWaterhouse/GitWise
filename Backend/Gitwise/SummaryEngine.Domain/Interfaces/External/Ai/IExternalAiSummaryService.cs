using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.External.Ai;

public interface IExternalAiSummaryService
{
    public Task<string> GetAiGeneratedSummaryAsync(
        Dictionary<string, List<Commit>> repositoryCommits, 
        CancellationToken ct);
}