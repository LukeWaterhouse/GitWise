namespace Gitwise.Domain.Models;

public record Commit(
    string Sha,
    Organisation Organisation,
    Repository Repository,
    Author Author,
    DateTime Date,
    string Message,
    ChangeStats TotalChanges,
    List<FileChange> FileChanges);