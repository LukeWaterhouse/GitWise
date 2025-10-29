namespace SummaryEngine.Infrastructure.Ai.Azure.Models.AiPrompts.Commit;

public record AiPromptChangeStats(
    int Total,
    int Additions,
    int Deletions);