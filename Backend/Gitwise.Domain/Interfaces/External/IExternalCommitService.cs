using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalCommitService
{
    public Task<List<Commit>> GetDailyCommitsAsync(
        string organisationName,
        Repository repository, 
        string authorEmail,
        DateTime date,
        CancellationToken ct);
}