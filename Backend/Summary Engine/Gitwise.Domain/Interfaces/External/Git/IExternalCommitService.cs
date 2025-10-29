using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External.Git;

public interface IExternalCommitService
{
    public Task<List<Commit>> GetDailyCommitsAsync(
        Organisation organisation,
        string authorUsername,
        DateTime date,
        CancellationToken ct);
}