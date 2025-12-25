using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Domain.Models;

public class SummaryJob
{
    public Guid JobId { get; set; }
    public Guid DeveloperId { get; set; }
    public Guid TenantId { get; set; }
    public DateTime SummaryDate { get; set; }
    public JobStatus Status { get; set; }
    public DateTimeOffset RequestedAt { get; set; }
    public DateTimeOffset? StartedAt { get; set; }
    public DateTimeOffset? CompletedAt { get; set; }
    public Guid? SummaryId { get; set; }
}