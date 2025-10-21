using GitWise.Api.Models;
using Gitwise.Domain.Models;

namespace GitWise.Api.Mapping;

public static class FileChangeMapper
{
    public static FileChangeDto FromDomain(this FileChange fileChange)
    {
        return new FileChangeDto(
            fileChange.BlobSha,
            fileChange.FileName,
            fileChange.ChangeStats.FromDomain(),
            fileChange.ChangeDefinition);
    }
}