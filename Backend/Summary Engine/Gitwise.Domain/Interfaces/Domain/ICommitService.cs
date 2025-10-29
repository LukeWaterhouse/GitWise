using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.Domain;

public interface ICommitService
{
    public Task<Dictionary<string, List<Commit>>> GetDailyRepoCommitsByUserAsync(
        string? organisationName,
        string AuthorUsername,
        DateTime date,
        CancellationToken ct);
}