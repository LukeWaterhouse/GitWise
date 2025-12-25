namespace Gitwise.Api.Models;

public record ChangeStatsDto(
    int Total,
    int Additions,
    int Deletions );