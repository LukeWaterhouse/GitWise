using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.External.Git;

public interface IExternalFileSnapshotService
{
    public Task<FileSnapshot> GetFileSnapshotAsync(
        Commit associatedCommit, 
        FileChange associatedFileChange,
        CancellationToken ct);
}