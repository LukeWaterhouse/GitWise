using Gitwise.Domain.Models;
using Gitwise.Domain.Models.Commit;

namespace Gitwise.Domain.Interfaces.Domain;

public interface ICommitService
{
    public Task<Dictionary<string, List<Commit>>> GetAllRepoCommitsAsync(
        string organisationName,
        string authorEmail,
        DateTime date,
        CancellationToken ct);
}