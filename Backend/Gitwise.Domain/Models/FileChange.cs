namespace Gitwise.Domain.Models;

public record FileChange(
    string FileSnapshotSha,
    string FileName,
    ChangeStats ChangeStats,
    string ChangeDefinition);