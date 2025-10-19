namespace Gitwise.Domain.Models.Commits;

public record Commit(
    string Sha,
    Repository Repository,
    Author Author,
    DateTime Date,
    string Message,
    ChangeStats TotalChanges,
    List<FileChange> FileChanges);