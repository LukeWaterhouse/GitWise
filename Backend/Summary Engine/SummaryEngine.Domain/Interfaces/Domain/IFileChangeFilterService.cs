using SummaryEngine.Domain.Models;

namespace SummaryEngine.Domain.Interfaces.Domain;

public interface IFileChangeFilterService
{
    public Dictionary<string, List<Commit>> FilterFileChangesForSummarization(
        Dictionary<string, List<Commit>> repositoryCommits);
}