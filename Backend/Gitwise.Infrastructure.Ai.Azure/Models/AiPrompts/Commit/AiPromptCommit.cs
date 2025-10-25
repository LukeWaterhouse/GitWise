namespace Gitwise.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

public record AiPromptCommit(
    string Message,
    AiPromptChangeStats CommitChangeStats,
    List<AiPromptFileChange> FileChanges
    );