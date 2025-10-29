namespace GitWise.Api.Models;

public record ChangeStatsDto(
    int Total,
    int Additions,
    int Deletions );