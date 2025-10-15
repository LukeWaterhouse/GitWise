namespace GitWise.Adapter.Github.Models.Commit;

public record GithubCommit(
    string Sha,
    string NodeId,
    GithubCommitDetail Commit,
    string HtmlUrl);