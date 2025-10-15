using Gitwise.Domain.Models.Commits;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalCommitService
{
    public Task<Commits> GetRepositoryCommitsAsync(
        string organisationName, 
        string repositoryName, 
        string authorEmail, 
        DateTime since, 
        DateTime until, 
        CancellationToken ct);
}