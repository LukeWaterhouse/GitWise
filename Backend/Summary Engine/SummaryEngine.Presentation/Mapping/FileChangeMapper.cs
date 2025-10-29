using SummaryEngine.Domain.Models;
using SummaryEngine.Presentation.Models;

namespace SummaryEngine.Presentation.Mapping;

public static class FileChangeMapper
{
    public static FileChangeDto FromDomain(this FileChange fileChange)
    {
        return new FileChangeDto(
            fileChange.FileSnapshotSha,
            fileChange.FileName,
            fileChange.ChangeStats.FromDomain(),
            fileChange.ChangeDefinition);
    }
}