using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.Domain;

public interface ICommitService
{
    public Task<Dictionary<string, List<Commit>>> GetDailyRepoCommitsByUserAsync(
        string? organisationName,
        string AuthorUsername,
        DateTime date,
        CancellationToken ct);
}