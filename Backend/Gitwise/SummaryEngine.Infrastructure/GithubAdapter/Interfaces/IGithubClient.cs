using SummaryEngine.Adapter.Github.GithubAdapter.Models.Blob;
using SummaryEngine.Adapter.Github.GithubAdapter.Models.Commit;
using SummaryEngine.Adapter.Github.GithubAdapter.Models.DetailedCommit;
using SummaryEngine.Adapter.Github.GithubAdapter.Models.Organisation;
using SummaryEngine.Adapter.Github.GithubAdapter.Models.Repository;

namespace SummaryEngine.Adapter.Github.GithubAdapter.Interfaces;

public interface IGithubClient
{
    public Task<GithubOrganisation> GetOrganisationAsync(string organisationName, CancellationToken ct);
    
    public Task<List<GithubRepository>> GetOrganisationReposAsync(string organisationName, CancellationToken ct);
    
    public Task<List<GithubCommit>> GetDailyCommitsAsync(
        string organisationName, 
        string authorUsername,
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