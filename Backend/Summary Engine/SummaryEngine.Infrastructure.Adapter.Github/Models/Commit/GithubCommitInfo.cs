namespace SummaryEngine.Adapter.Github.Models.Commit;

public record GithubCommitInfo(
    GithubCommitAuthor Author,
    string Message );