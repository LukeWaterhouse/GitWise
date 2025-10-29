namespace Gitwise.Domain.Models;

public record ChangeStats(
    int Total,
    int Additions,
    int Deletions);