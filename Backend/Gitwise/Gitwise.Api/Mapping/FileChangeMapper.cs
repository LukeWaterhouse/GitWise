using Gitwise.Api.Models;
using SummaryEngine.Domain.Models;

namespace Gitwise.Api.Mapping;

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