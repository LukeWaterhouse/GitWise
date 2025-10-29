using GitWise.Adapter.Github.Interfaces;
using Gitwise.Domain.Interfaces.External.Git;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubOrganisationService(IGithubClient githubClient) : IExternalOrganisationService
{
    public async Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct)
    {
        var githubOrganisation = await githubClient.GetOrganisationAsync(organisationName, ct);

        return new Organisation(githubOrganisation.Name, githubOrganisation.Description, githubOrganisation.Location);
    }
}