using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.Domain;

public interface IFileChangeFilterService
{
    public Dictionary<string, List<Commit>> FilterFileChangesForSummarization(
        Dictionary<string, List<Commit>> repositoryCommits);
}