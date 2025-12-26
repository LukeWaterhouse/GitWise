namespace ControlPlane.Application.Interfaces.External;

public interface IMessageService : IAsyncDisposable
{
    Task PublishWorkSummaryRequestAsync(Guid jobId, Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct);
}