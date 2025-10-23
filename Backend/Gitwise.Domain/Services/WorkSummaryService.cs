using Gitwise.Domain.Interfaces.Domain;

namespace Gitwise.Domain.Services;

public class WorkSummaryService(ICommitService commitService) : IWorkSummaryService
{
    public async Task<string> GenerateDailyWorkSummaryAsync(string organisationName, string userEmail, DateTime date, CancellationToken ct)
    {
        var commitsByRepository = await commitService.GetDailyRepoCommitsByUserAsync(organisationName, userEmail, date, ct);
        
        return "work summary";
    }
}