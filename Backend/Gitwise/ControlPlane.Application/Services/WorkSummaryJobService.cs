using ControlPlane.Application.Interfaces;
using ControlPlane.Domain.Models.Enums;

namespace ControlPlane.Application.Services;

public class WorkSummaryJobService(IRepositoryService repositoryService, IMessageService messageService) : IWorkSummaryJobService
{
    public async Task<Guid> GetWorkSummaryRequestJobIdAsync(Guid tenantId, Guid developerId, DateOnly date, CancellationToken ct)
    {
        var job = await repositoryService.TryGetSummaryJobAsync(tenantId, developerId, date, ct);
 
        if (job != null)
        {
            if (job.Status == JobStatus.Processing ||
                (job is { Status: JobStatus.Completed, CompletedAt: not null } && job.CompletedAt.Value > DateTimeOffset.UtcNow.AddMinutes(-10)))
            {
                return job.JobId;
            }
            
            await messageService.PublishWorkSummaryRequestAsync(job.JobId, tenantId, developerId, date);
            return job.JobId;
        }
        
        var jobId = await repositoryService.CreateSummaryJobAsync(tenantId, developerId, date, ct);
        await messageService.PublishWorkSummaryRequestAsync(jobId, tenantId, developerId, date);
        
        return jobId;
    }
}