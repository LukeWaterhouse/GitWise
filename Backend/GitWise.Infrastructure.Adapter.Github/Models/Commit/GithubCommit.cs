namespace GitWise.Adapter.Github.Models.Commit;

public record GithubCommit(
    string Sha,
    string NodeId,
    GithubCommitInfo Commit,
    string Html_Url);