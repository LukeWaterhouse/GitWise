namespace SummaryEngine.Application.Interfaces;

public interface IWorkSummaryService
{
    Task<string> GenerateDailyWorkSummaryAsync(Guid jobId, Guid tenantId, Guid developerId, DateTime date);
}