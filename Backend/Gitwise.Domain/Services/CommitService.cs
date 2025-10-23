using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace Gitwise.Domain.Services;

public class CommitService(
    IExternalCommitService externalCommitService,
    IExternalOrganisationService externalOrganisationService) : ICommitService
{
    public async Task<Dictionary<string, List<Commit>>> GetDailyRepoCommitsByUserAsync(
        string? organisationName,
        string authorUsername,
        DateTime date,
        CancellationToken ct)
    {
        Organisation organisation;
        
        if (string.IsNullOrEmpty(organisationName))
        {
            organisation = new Organisation(authorUsername, "", "");
        }
        else
        {
            organisation = await externalOrganisationService.GetOrganisationByNameAsync(organisationName, ct);
        }

        var commits = await externalCommitService.GetDailyCommitsAsync(organisation, authorUsername, date, ct);

        var groupedCommits = commits
            .GroupBy(commit => commit.Repository.Name)
            .ToDictionary(g => g.Key, g => g.ToList());

        return groupedCommits;
    }
}