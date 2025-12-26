namespace SummaryEngine.Infrastructure.Azure.AzureAi.Models.AiPrompts.Commit;

public record AiPromptChangeStats(
    int Total,
    int Additions,
    int Deletions);