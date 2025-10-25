namespace Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

public record AiPromptFileChange(
    string FileName,
    AiPromptChangeStats FileChangeStats,
    string DiffSnippet,
    string? FileSnapshotContent);