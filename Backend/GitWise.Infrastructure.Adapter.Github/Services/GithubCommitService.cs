using GitWise.Adapter.Github.Interfaces;
using GitWise.Adapter.Github.Models.DetailedCommit;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubCommitService(IGithubClient githubClient) : IExternalCommitService
{
    public async Task<List<Commit>> GetDailyCommitsAsync(
        Organisation organisation, 
        string authorUsername,
        DateTime date,
        CancellationToken ct)
    {
        var commitList = await githubClient.GetDailyCommitsAsync(
            organisation.Name, 
            authorUsername,
            date,
            ct);

        var detailedCommitList = new List<GithubDetailedCommit>();
        foreach (var commit in commitList)
        {
            var detailedCommit = await githubClient.GetCommitDetailsAsync(
                organisation.Name,
                commit.Repository.Name,
                commit.Sha,
                ct);
            detailedCommitList.Add(detailedCommit);
        }

        var result = new List<Commit>();
        for (var i = 0; i < detailedCommitList.Count; i++)
        {
            var detailedCommit = detailedCommitList[i];
            var commit = commitList[i];

            result.Add(new Commit(
                detailedCommit.Sha,
                organisation,
                new Repository(
                    commit.Repository.Name,
                    commit.Repository.Full_Name,
                    commit.Repository.Html_Url,
                    commit.Repository.Private,
                    commit.Repository.Description),
                new Author(detailedCommit.Commit.Author.Name, detailedCommit.Commit.Author.Email),
                detailedCommit.Commit.Author.Date,
                detailedCommit.Commit.Message,
                new(detailedCommit.Stats.Total, detailedCommit.Stats.Additions, detailedCommit.Stats.Deletions),
                detailedCommit.Files.Select(x =>
                    new FileChange(
                        x.Sha,
                        x.Filename,
                        new ChangeStats(x.Changes, x.Additions, x.Deletions),
                        x.Patch)).ToList()
            ));
        }

        return result;
    }
}
