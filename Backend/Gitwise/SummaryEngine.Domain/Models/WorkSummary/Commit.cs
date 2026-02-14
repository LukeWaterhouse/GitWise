namespace SummaryEngine.Domain.Models.WorkSummary;

public record Commit(
    string Sha,
    Organisation Organisation,
    Repository Repository,
    Author Author,
    DateTime Date,
    string Message,
    ChangeStats TotalChanges,
    List<FileChange> FileChanges);
    