namespace GitWise.Adapter.Github.Models.Commit;

public record GithubCommitAuthor(
    string Name,
    string Email,
    DateTime Date );