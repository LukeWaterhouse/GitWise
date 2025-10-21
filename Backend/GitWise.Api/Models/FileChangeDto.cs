namespace GitWise.Api.Models;

public record FileChangeDto(
    string BlobSha,
    string FileName,
    ChangeStatsDto ChangeStats,
    string ChangeDefinition);