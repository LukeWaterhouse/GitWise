namespace SummaryEngine.Infrastructure.Azure.Ai.Models.AiPrompts.Commit;

public record AiPromptCommit(
    string Message,
    AiPromptChangeStats CommitChangeStats,
    List<AiPromptFileChange> FileChanges
    );