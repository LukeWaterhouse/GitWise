using SummaryEngine.Adapter.Github.Interfaces;
using SummaryEngine.Domain.Interfaces.External.Git;
using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.Enums;

namespace SummaryEngine.Adapter.Github.Services;

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
            GetDecodedContent(blob.Content),
            encodingType); 
    }
    
    private static string? GetDecodedContent(string encodedContent)
    {
        var base64EncodedBytes = Convert.FromBase64String(encodedContent);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
}