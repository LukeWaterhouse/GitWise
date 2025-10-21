using GitWise.Api.Models.Commit;
using Gitwise.Domain.Models;

namespace GitWise.Api.Mapping;

public static class CommitMapper
{
    public static CommitDto FromDomain(this Commit commit)
    {
        return new CommitDto(
            commit.Sha,
            commit.Repository.FromDomain(),
            commit.Author.FromDomain(),
            commit.Date,
            commit.Message,
            commit.TotalChanges.FromDomain(),
            commit.FileChanges.Select(x => x.FromDomain()).ToList());
    }
}