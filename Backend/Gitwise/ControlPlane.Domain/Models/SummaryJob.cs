using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Domain.Models;

public class SummaryJob(
    Guid jobId,
    Guid developerId,
    Guid tenantId,
    DateTime summaryDate,
    JobStatus status,
    DateTimeOffset requestedAt,
    DateTimeOffset? startedAt,
    DateTimeOffset? completedAt,
    Guid? summaryId)
{
    public Guid JobId { get; set; } = jobId;
    public Guid DeveloperId { get; set; } = developerId;
    public Guid TenantId { get; set; } = tenantId;
    public DateTime SummaryDate { get; set; } = summaryDate;
    public JobStatus Status { get; set; } = status;
    public DateTimeOffset RequestedAt { get; set; } = requestedAt;
    public DateTimeOffset? StartedAt { get; set; } = startedAt;
    public DateTimeOffset? CompletedAt { get; set; } = completedAt;
    public Guid? SummaryId { get; set; } = summaryId;
}