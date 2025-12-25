using SummaryEngine.Adapter.Github.Models.Blob;
using SummaryEngine.Adapter.Github.Models.Commit;
using SummaryEngine.Adapter.Github.Models.DetailedCommit;
using SummaryEngine.Adapter.Github.Models.Organisation;
using SummaryEngine.Adapter.Github.Models.Repository;

namespace SummaryEngine.Adapter.Github.Interfaces;

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