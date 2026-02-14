namespace SummaryEngine.Adapter.Github.GithubAdapter.Models.Commit;

public record GithubCommitAuthor(
    string Name,
    string Email,
    DateTime Date );