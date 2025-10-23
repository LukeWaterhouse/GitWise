using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Models.DetailedCommit;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubCommitService(IGithubClient githubClient) : IExternalCommitService
{
    public async Task<List<Commit>> GetDailyCommitsAsync(
        Organisation organisation, 
        Repository repository, 
        string authorEmail,
        DateTime date,
        CancellationToken ct)
    {
        var commitList = await githubClient.GetDailyCommitsAsync(
            organisation.Name, 
            repository.Name, 
            authorEmail,
            date,
            ct);
        
        var detailedCommitList = new List<GithubDetailedCommit>();

        foreach (var commit in commitList)
        {
            var detailedCommit = await githubClient.GetCommitDetailsAsync(
                organisation.Name,
                repository.Name,
                commit.Sha,
                ct);
            
            detailedCommitList.Add(detailedCommit);
        }

        return detailedCommitList.Select(detailedCommit => 
            new Commit(
                detailedCommit.Sha,
                organisation,
                repository, 
                new Author(detailedCommit.Commit.Author.Name, detailedCommit.Commit.Author.Email ), 
                detailedCommit.Commit.Author.Date, 
                detailedCommit.Commit.Message, 
                new(detailedCommit.Stats.Total, detailedCommit.Stats.Additions, detailedCommit.Stats.Deletions), 
                detailedCommit.Files.Select(x => 
                    new FileChange(
                        x.Sha, 
                        x.Filename, 
                        new ChangeStats(x.Changes, x.Additions, x.Deletions), 
                        x.Patch)).ToList())
        ).ToList();
    }
}