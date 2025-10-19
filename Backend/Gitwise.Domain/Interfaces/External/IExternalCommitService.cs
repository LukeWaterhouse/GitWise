using Gitwise.Domain.Models;
using Gitwise.Domain.Models.Commit;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalCommitService
{
    public Task<List<Commit>> GetCommitsAsync(
        string organisationName,
        Repository repository, 
        Author authorEmail,
        DateTime date,
        CancellationToken ct);
}