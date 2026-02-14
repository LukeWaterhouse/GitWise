using SummaryEngine.Adapter.Github.GithubAdapter.Interfaces;
using SummaryEngine.Domain.Interfaces.External.Git;
using SummaryEngine.Domain.Models;

namespace SummaryEngine.Adapter.Github.GithubAdapter.Services;

public class GithubRepositoryService(IGithubClient githubClient) : IExternalRepositoryService
{
    public async Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct)
    {
        var githubRepos = await githubClient.GetOrganisationReposAsync(organisationName, ct);
        var repos = githubRepos.Select(x => new Repository(x.Name, x.Full_Name, x.Html_Url, x.Private, x.Description)).ToList();
        
        return repos;
    }
}