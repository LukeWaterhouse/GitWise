namespace SummaryEngine.Domain.Models.WorkSummary;

public record ChangeStats(
    int Total,
    int Additions,
    int Deletions);