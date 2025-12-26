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

    public static SummaryJob ToDomain(this DbSummaryJob dbSummaryJob)
    {
        return new SummaryJob(
            dbSummaryJob.JobId,
            dbSummaryJob.DeveloperId,
            dbSummaryJob.TenantId,
            dbSummaryJob.SummaryDate.ToDateTime(TimeOnly.MinValue),
            (JobStatus)dbSummaryJob.Status,
            dbSummaryJob.RequestedAt,
            dbSummaryJob.StartedAt,
            dbSummaryJob.CompletedAt,
            dbSummaryJob.ExistingSummaryId
        );
    }
}