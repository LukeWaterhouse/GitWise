using SummaryEngine.Adapter.Github.GithubAdapter.Interfaces;
using SummaryEngine.Domain.Interfaces.External.Git;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Adapter.Github.GithubAdapter.Services;

public class GithubOrganisationService(IGithubClient githubClient) : IExternalOrganisationService
{
    public async Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct)
    {
        var githubOrganisation = await githubClient.GetOrganisationAsync(organisationName, ct);

        return new Organisation(githubOrganisation.Name, githubOrganisation.Description, githubOrganisation.Location);
    }
}