using ControlPlane.Application.Exceptions;
using ControlPlane.Application.Exceptions.Enums;
using ControlPlane.Application.Interfaces.External.Repository;
using ControlPlane.Domain.Models;
using ControlPlane.Infrastructure.AzureSql.EfCore;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models.Enums;
using ControlPlane.Infrastructure.AzureSql.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ControlPlane.Infrastructure.AzureSql.Services;

public class DbSummaryJobRepositoryService(IDbContextFactory<ControlPlaneDbContext> dbContextFactory) : ISummaryJobRepositoryService
{
    public async Task<SummaryJob?> TryGetSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
        
        var dbSummaryJob = await dbContext.SummaryJobs
            .FirstOrDefaultAsync(s => s.TenantId == tenantId &&
                                       s.DeveloperId == developerId &&
                                       s.SummaryDate == summaryDate, ct);

        return dbSummaryJob?.ToDomain();
    }

    public async Task<SummaryJob> CreateSummaryJobAsync(Guid tenantId, Guid developerId, DateOnly summaryDate, CancellationToken ct)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(ct);
        
        var existingDbSummaryJob = await dbContext.SummaryJobs
            .FirstOrDefaultAsync(s => s.TenantId == tenantId &&
                                      s.DeveloperId == developerId &&
                                      s.SummaryDate == summaryDate, ct);

        if (existingDbSummaryJob != null)
        {
            throw new DuplicateRecordException(RecordType.SummaryJob, $"TenantId:{tenantId}-DeveloperId:{developerId}-{summaryDate}");
        }
        
        var dbTenant = await dbContext.Tenants.FirstOrDefaultAsync(t => t.Id == tenantId, ct);
        if (dbTenant == null)
        {
            throw new RecordNotFoundException(RecordType.Tenant, tenantId.ToString());
        }
        
        var dbDeveloper = await dbContext.Developers.FirstOrDefaultAsync(d => d.Id == developerId, ct);
        if (dbDeveloper == null)
        {
            throw new RecordNotFoundException(RecordType.Developer, developerId.ToString());
        }
        
        var currentTime = DateTimeOffset.UtcNow;

        var newDbSummaryJob = new DbWorkSummaryJob()
        {
            JobId = Guid.NewGuid(),
            TenantId = dbTenant.Id,
            Tenant = dbTenant,
            DeveloperId = dbDeveloper.Id,
            Developer = dbDeveloper,
            SummaryDate = summaryDate,
            Status = DbJobStatus.Processing,
            RequestedAt = currentTime,
            StartedAt = null,
            CompletedAt = null,
            ExistingSummaryId = null
        };
        
        dbContext.SummaryJobs.Add(newDbSummaryJob);
        await dbContext.SaveChangesAsync(ct);
        
        return newDbSummaryJob.ToDomain();
    }
}