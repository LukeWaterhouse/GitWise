using Gitwise.Domain.Models.Enums;

namespace Gitwise.Domain.Models;

public record FileSnapshot(
    FileChange AssociatedFileChange,
    Commit AssociatedCommit,
    int Size,
    string EncodedContent,
    EncodingType EncodingType);