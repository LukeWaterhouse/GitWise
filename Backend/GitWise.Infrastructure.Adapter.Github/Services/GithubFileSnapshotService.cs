using GitWise.Adapter.Github.Interfaces;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace GitWise.Adapter.Github.Services;

public class GithubFileSnapshotService(IGithubClient githubClient) : IExternalFileSnapshotService
{
    public Task<FileSnapshot> GetFileSnapshotAsync(string commitSha, CancellationToken ct)
    {
        
        
        throw new NotImplementedException();
    }
}