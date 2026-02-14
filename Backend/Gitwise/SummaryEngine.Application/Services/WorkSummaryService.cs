using SummaryEngine.Application.Interfaces;

namespace SummaryEngine.Application.Services;

public class WorkSummaryService : IWorkSummaryService
{
    public Task<string> GenerateDailyWorkSummaryAsync(Guid jobId, Guid tenantId, Guid developerId, DateTime date)
    {
        throw new NotImplementedException();
    }
}