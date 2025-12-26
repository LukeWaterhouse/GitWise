namespace SummaryEngine.Infrastructure.Azure.AzureAi.Models.AiPrompts.Commit;

public record AiPromptCommit(
    string Message,
    AiPromptChangeStats CommitChangeStats,
    List<AiPromptFileChange> FileChanges
    );