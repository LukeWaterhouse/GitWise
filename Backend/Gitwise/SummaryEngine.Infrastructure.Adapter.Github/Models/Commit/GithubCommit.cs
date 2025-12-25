using SummaryEngine.Adapter.Github.Models.Repository;

namespace SummaryEngine.Adapter.Github.Models.Commit;

public record GithubCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubRepository Repository,
    string Html_Url);