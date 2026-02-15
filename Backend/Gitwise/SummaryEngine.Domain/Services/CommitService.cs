using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Domain.Interfaces.External.Git;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Services;

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

        var repositoryCommits = commits
            .GroupBy(commit => commit.Repository.Name)
            .ToDictionary(g => g.Key, g => g.ToList());

        return repositoryCommits;
    }
}