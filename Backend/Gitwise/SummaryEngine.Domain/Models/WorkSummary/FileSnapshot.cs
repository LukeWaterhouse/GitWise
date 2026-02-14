using SummaryEngine.Domain.Models.WorkSummary.Enums;

namespace SummaryEngine.Domain.Models.WorkSummary;

public record FileSnapshot(
    FileChange AssociatedFileChange,
    Commit AssociatedCommit,
    int Size,
    string EncodedContent,
    string? DecodedContent,
    EncodingType EncodingType);