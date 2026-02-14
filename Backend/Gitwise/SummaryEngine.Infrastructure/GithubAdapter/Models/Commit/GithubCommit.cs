using SummaryEngine.Adapter.Github.GithubAdapter.Models.Repository;

namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.Commit;

public record GithubCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubRepository Repository,
    string Html_Url);