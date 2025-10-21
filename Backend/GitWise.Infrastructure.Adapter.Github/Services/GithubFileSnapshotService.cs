using GitWise.Adapter.Github.Interfaces;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubFileSnapshotService(IGithubClient githubClient) : IExternalFileSnapshotService
{
    public async Task<FileSnapshot> GetFileSnapshotAsync(
        Commit associatedCommit, 
        FileChange associatedFileChange, 
        string fileSnapshotSha,
        CancellationToken ct)
    {
        var blob = await githubClient.GetBlobAsync(
            associatedCommit.,
    }
}