namespace GitWise.Adapter.Github.Models.Commit;

public record GithubCommitDetail(
    GithubCommitAuthor Author,
    string Message );