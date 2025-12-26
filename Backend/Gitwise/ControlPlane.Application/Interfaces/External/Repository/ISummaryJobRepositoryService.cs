using ControlPlane.Domain.Models;

namespace ControlPlane.Application.Interfaces.External.Repository;

public interface ISummaryJobRepositoryService
{
    Task<SummaryJob?> TryGetSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct);
    
    Task<SummaryJob> CreateSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct);
}