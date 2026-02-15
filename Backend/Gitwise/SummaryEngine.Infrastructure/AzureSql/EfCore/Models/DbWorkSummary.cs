using System.ComponentModel.DataAnnotations;

namespace SummaryEngine.Adapter.Github.AzureSql.EfCore.Models;

public class DbWorkSummary
{
    [Key]
    public Guid WorkSummaryId { get; set; }

    [Required]
    public Guid TenantId { get; set; }

    [Required]
    public Guid DeveloperId { get; set; }

    public DateOnly SummaryDate { get; set; }

    public int Version { get; set; }

    public string SummaryText { get; set; } = string.Empty;

    public string LastCommitSha { get; set; }

    public DateTimeOffset LastCommitTimestamp { get; set; }

    public int CommitCount { get; set; }

    public DateTimeOffset GeneratedAt { get; set; }

    public Guid JobId { get; set; }
}