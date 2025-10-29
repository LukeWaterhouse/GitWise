using GitWise.Adapter.Github.Models.Repository;

namespace GitWise.Adapter.Github.Models.Commit;

public record GithubCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    GithubRepository Repository,
    string Html_Url);