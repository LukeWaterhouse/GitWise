using GitWise.Adapter.Github.Models.Blob;
using GitWise.Adapter.Github.Models.Commit;
using GitWise.Adapter.Github.Models.DetailedCommit;
using GitWise.Adapter.Github.Models.Organisation;
using GitWise.Adapter.Github.Models.Repository;

namespace GitWise.Adapter.Github.Interfaces;

public interface IGithubClient
{
    public Task<GithubOrganisation> GetOrganisationAsync(string organisationName, CancellationToken ct);
    
    public Task<List<GithubRepository>> GetOrganisationReposAsync(string organisationName, CancellationToken ct);
    
    public Task<List<GithubCommit>> GetDailyCommitsAsync(
        string organisationName, 
        string repositoryName, 
        string authorEmail,
        DateTime date,
        CancellationToken ct);
    
    public Task<GithubDetailedCommit> GetCommitDetailsAsync(
        string organisationName,
        string repositoryName,
        string commitSha,
        CancellationToken ct);
    
    public Task<GithubBlob> GetBlobAsync(
        string organisationName,
        string repositoryName,
        string blobSha,
        CancellationToken ct);
}