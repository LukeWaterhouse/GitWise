using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.Domain;

public interface ICommitService
{
    public Task<Dictionary<string, List<Commit>>> GetAllRepoCommitsAsync(
        string organisationName,
        string userEmail,
        DateTime date,
        CancellationToken ct);
}