using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External.Git;

public interface IExternalFileSnapshotService
{
    public Task<FileSnapshot> GetFileSnapshotAsync(
        Commit associatedCommit, 
        FileChange associatedFileChange,
        CancellationToken ct);
}