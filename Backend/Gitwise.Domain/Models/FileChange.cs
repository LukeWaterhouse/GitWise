namespace Gitwise.Domain.Models;

public record FileChange(
    string BlobSha,
    string FileName,
    ChangeStats ChangeStats,
    string ChangeDefinition);