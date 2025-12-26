namespace SummaryEngine.Infrastructure.Azure.AzureAi.Models.AiPrompts.Commit;

public record AiPromptFileChange(
    string FileName,
    AiPromptChangeStats FileChangeStats,
    string? DiffSnippet,
    string? FileSnapshotContent);