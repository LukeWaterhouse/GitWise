using SummaryEngine.Domain.Models.Enums;

namespace SummaryEngine.Domain.Models;

public record FileSnapshot(
    FileChange AssociatedFileChange,
    Commit AssociatedCommit,
    int Size,
    string EncodedContent,
    string? DecodedContent,
    EncodingType EncodingType);