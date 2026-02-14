using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.Domain;

public interface IFileChangeFilterService
{
    public Dictionary<string, List<Commit>> FilterFileChangesForSummarization(
        Dictionary<string, List<Commit>> repositoryCommits);
}