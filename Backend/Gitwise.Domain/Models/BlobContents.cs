namespace Gitwise.Domain.Models;

public record BlobContents(
    FileChange AssociatedFileChange,
    Commit.Commit AssociatedCommit,
    int Size,
    string EncodedContents);