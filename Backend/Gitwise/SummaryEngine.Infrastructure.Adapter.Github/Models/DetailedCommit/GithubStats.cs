namespace SummaryEngine.Adapter.Github.Models.DetailedCommit;

public record GithubStats(
    int Additions,
    int Deletions,
    int Total);