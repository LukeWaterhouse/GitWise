namespace Gitwise.Domain.Models.Commits;

public record Commit(
    CommitAuthor Author,
    DateTime Date,
    string Message);