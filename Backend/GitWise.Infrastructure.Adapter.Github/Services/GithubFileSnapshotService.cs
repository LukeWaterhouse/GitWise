using GitWise.Adapter.Github.Interfaces;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;
using Gitwise.Domain.Models.Enums;

namespace GitWise.Adapter.Github.Services;

public class GithubFileSnapshotService(IGithubClient githubClient) : IExternalFileSnapshotService
{
    public async Task<FileSnapshot> GetFileSnapshotAsync(
        Commit associatedCommit, 
        FileChange associatedFileChange, 
        CancellationToken ct)
    {
        var blob = await githubClient.GetBlobAsync(
            associatedCommit.Organisation.Name,
            associatedCommit.Repository.Name,
            associatedFileChange.FileSnapshotSha,
            ct);
        
        if (!Enum.TryParse(blob.Encoding, ignoreCase: true, out EncodingType encodingType))
        {
            throw new ArgumentException($"Invalid encoding type: {blob.Encoding}");
        }
        
        return new FileSnapshot(
            associatedFileChange,
            associatedCommit,
            blob.Size,
            blob.Content,
            encodingType); 
    }
}