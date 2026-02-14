using ControlPlane.Domain.Models;
using ControlPlane.Domain.Models.Enums;
using ControlPlane.Infrastructure.AzureSql.EfCore.Models;

namespace ControlPlane.Infrastructure.AzureSql.Mapping;

public static class MappingExtensions
{
    public static User ToDomain(this DbUser dbUser)
    {
        return new User(dbUser.Id, dbUser.TenantId, dbUser.Email, (Role)dbUser.DbRole, dbUser.AzureObjectId);
    }
    
    public static Tenant ToDomain(this DbTenant dbTenant)
    {
        return new Tenant(dbTenant.Id, dbTenant.Name);
    }

    public static SummaryJob ToDomain(this DbWorkSummaryJob dbWorkSummaryJob)
    {
        return new SummaryJob(
            dbWorkSummaryJob.JobId,
            dbWorkSummaryJob.DeveloperId,
            dbWorkSummaryJob.TenantId,
            dbWorkSummaryJob.SummaryDate.ToDateTime(TimeOnly.MinValue),
            (JobStatus)dbWorkSummaryJob.Status,
            dbWorkSummaryJob.RequestedAt,
            dbWorkSummaryJob.StartedAt,
            dbWorkSummaryJob.CompletedAt,
            dbWorkSummaryJob.ExistingSummaryId
        );
    }
}