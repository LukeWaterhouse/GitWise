using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;

namespace ControlPlane.Infrastructure.AzureSql.EfCore.Models;

public class DbWorkSummaryJob
{
    [Key]
    public Guid JobId { get; set; }

    [ForeignKey(nameof(Tenant))]
    public Guid TenantId { get; set; }
    public DbTenant Tenant { get; set; } = null!;

    [ForeignKey(nameof(Developer))]
    public Guid DeveloperId { get; set; }
    public DbDeveloper Developer { get; set; } = null!;

    public DateOnly SummaryDate { get; set; }

    public DbJobStatus Status { get; set; }

    public DateTimeOffset RequestedAt { get; set; }
    public DateTimeOffset? StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public Guid? ExistingSummaryId { get; set; }
}