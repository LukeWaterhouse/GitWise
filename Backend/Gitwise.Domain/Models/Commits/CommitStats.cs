namespace Gitwise.Domain.Models.Commits;

public record CommitStats(
    int Total,
    int Additions,
    int Deletions);