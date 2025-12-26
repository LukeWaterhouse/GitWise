using ControlPlane.Application.Interfaces.Application;
using ControlPlane.Application.Interfaces.External;
using ControlPlane.Application.Interfaces.External.Repository;
using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Application.Services;

public class WorkSummaryJobService(ISummaryJobRepositoryService summaryJobRepositoryService, IMessageService messageService) : IWorkSummaryJobService
{
    public async Task<Guid> GetWorkSummaryRequestJobIdAsync(Guid tenantId, Guid developerId, DateOnly date, CancellationToken ct)
    {
        var job = await summaryJobRepositoryService.TryGetSummaryJobAsync(tenantId, developerId, date, ct);
 
        if (job != null)
        {
            if (job.Status == JobStatus.Processing ||
                (job is { Status: JobStatus.Completed, CompletedAt: not null } && job.CompletedAt.Value > DateTimeOffset.UtcNow.AddMinutes(-10)))
            {
                return job.JobId;
            }
            
            await messageService.PublishWorkSummaryRequestAsync(job.JobId, tenantId, developerId, date, ct);
            return job.JobId;
        }
        
        var summaryJob = await summaryJobRepositoryService.CreateSummaryJobAsync(tenantId, developerId, date, ct);
        await messageService.PublishWorkSummaryRequestAsync(summaryJob.JobId, tenantId, developerId, date, ct);
        
        return summaryJob.JobId;
    }
}