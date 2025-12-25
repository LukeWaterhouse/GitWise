namespace ControlPlane.Application.Interfaces;

public interface IMessageService : IAsyncDisposable
{
    Task PublishWorkSummaryRequestAsync(Guid jobId, Guid tenantId, Guid developerId, DateOnly summaryDate);
}