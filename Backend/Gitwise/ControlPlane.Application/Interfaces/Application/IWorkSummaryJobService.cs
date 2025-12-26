namespace ControlPlane.Application.Interfaces.Application;

public interface IWorkSummaryJobService
{
    Task<Guid> GetWorkSummaryRequestJobIdAsync(Guid tenantId, Guid developerId, DateOnly date, CancellationToken ct);
}