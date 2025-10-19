using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Models.DetailedCommit;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;
using Gitwise.Domain.Models.Commits;

namespace GitWise.Adapter.Github.Services;

public class GithubCommitService(IGithubClient githubClient) : IExternalCommitService
{
    public async Task<List<Commit>> GetCommitsAsync(
        string organisationName, 
        Repository repository, 
        Author author,
        DateTime date,
        CancellationToken ct)
    {
        var commitList = await githubClient.GetDailyCommitsAsync(
            organisationName, 
            repository.Name, 
            author.Email,
            date,
            ct);
        
        var detailedCommitList = new List<GithubDetailedCommit>();

        foreach (var commit in commitList)
        {
            var detailedCommit = await githubClient.GetCommitDetailsAsync(
                organisationName,
                repository.Name,
                commit.Sha,
                ct);
            
            detailedCommitList.Add(detailedCommit);
        }

        var commits = new List<Commit>();

        foreach (var detailedCommit in detailedCommitList)
        {
            var commit = new Commit(
                detailedCommit.Sha,
                repository,
                author,
                detailedCommit.Commit.Author.Date,
                detailedCommit.Commit.Message,
                new(detailedCommit.Stats.Total, detailedCommit.Stats.Additions, detailedCommit.Stats.Deletions),
                detailedCommit.Files.Select(x => new FileChange(
                    x.Sha,
                    x.Filename,
                    new ChangeStats(x.Changes, x.Additions, x.Deletions),
                    x.Patch)
                ).ToList());
            
            commits.Add(commit);
        }

        return commits;
    }
}