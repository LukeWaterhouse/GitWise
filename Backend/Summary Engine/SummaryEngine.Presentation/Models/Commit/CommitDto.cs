using SummaryEngine.Presentation.Models.Repository;

namespace SummaryEngine.Presentation.Models.Commit;

public record CommitDto(
    string Sha,
    RepositoryDto Repository,
    AuthorDto Author,
    DateTime Date,
    string Message,
    ChangeStatsDto TotalChanges,
    List<FileChangeDto> FileChanges);