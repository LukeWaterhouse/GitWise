using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.Repository;

namespace GitWise.Adapter.Github.Interfaces;

public interface IGithubClient
{
    public Task<List<GithubRepository>> GetOrganisationReposAsync(string organisationName, CancellationToken ct);
    
    public Task<List<GithubCommit>> GetRepositoryCommitsAsync(
        string organisationName, 
        string repositoryName, 
        string authorEmail, 
        DateTime since, 
        DateTime until, 
        CancellationToken ct);
}