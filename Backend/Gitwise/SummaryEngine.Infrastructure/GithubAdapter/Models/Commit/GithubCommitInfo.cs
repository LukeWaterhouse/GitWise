namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.Commit;

public record GithubCommitInfo(
    GithubCommitAuthor Author,
    string Message );