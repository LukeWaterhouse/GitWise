using GitWise.Adapter.Github.Interfaces;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubRepositoryService(IGithubClient githubClient) : IExternalRepositoryService
{
    public async Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct)
    {
        var githubRepos = await githubClient.GetOrganisationReposAsync(organisationName, ct);
        var repos = githubRepos.Select(x => new Repository(x.Name, x.Full_Name, x.Html_Url, x.Private, x.Description)).ToList();
        
        return repos;
    }
}