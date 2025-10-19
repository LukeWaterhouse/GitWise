using Gitwise.Domain.Models.Commits;

namespace Gitwise.Domain.Models;

public record BlobContents(
    FileChange AssociatedFileChange,
    Commit AssociatedCommit,
    int Size,
    string EncodedContents);