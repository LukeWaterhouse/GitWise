namespace Gitwise.Domain.Interfaces.Domain;

public interface IWorkSummaryService
{
    public Task<string> GenerateDailyWorkSummaryAsync(
        string organisationName, 
        string userEmail,
        DateTime date,
        CancellationToken ct);
}