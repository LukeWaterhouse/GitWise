namespace SummaryEngine.Infrastructure.Azure.Ai.Models.AiPrompts.Commit;

public record AiPromptChangeStats(
    int Total,
    int Additions,
    int Deletions);