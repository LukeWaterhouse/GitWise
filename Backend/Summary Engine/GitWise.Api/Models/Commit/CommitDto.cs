using GitWise.Api.Models.Repository;

namespace GitWise.Api.Models.Commit;

public record CommitDto(
    string Sha,
    RepositoryDto Repository,
    AuthorDto Author,
    DateTime Date,
    string Message,
    ChangeStatsDto TotalChanges,
    List<FileChangeDto> FileChanges);