using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalFileSnapshotService
{
    public Task<FileSnapshot> GetFileSnapshotAsync(string commitSha, CancellationToken ct);
}