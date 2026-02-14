namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.DetailedCommit;

public record GithubStats(
    int Additions,
    int Deletions,
    int Total);