using ControlPlane.Domain.Models;

namespace ControlPlane.Application.Interfaces;

public interface IRepositoryService
{
    Task<SummaryJob?> TryGetSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct);
    
    Task<Guid> CreateSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct);
}