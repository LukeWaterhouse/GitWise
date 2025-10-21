using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalFileSnapshotService
{
    public Task<FileSnapshot> GetFileSnapshotAsync(
        Commit associatedCommit, 
        FileChange associatedFileChange,
        string fileSnapshotSha, 
        CancellationToken ct);
}