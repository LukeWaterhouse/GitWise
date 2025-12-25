using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class SummaryJobs
{
    [Key]
    public Guid JobId { get; set; }

    [ForeignKey(nameof(Tenant))]
    public Guid TenantId { get; set; }
    public Tenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(Developer))]
    public Guid DeveloperId { get; set; }
    public Developer Developer { get; set; } = null!;

    public DateTime SummaryDate { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = string.Empty;

    public DateTimeOffset RequestedAt { get; set; }
    public DateTimeOffset? StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public Guid? ExistingSummaryId { get; set; }
}