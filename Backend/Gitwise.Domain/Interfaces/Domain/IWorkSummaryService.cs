namespace Gitwise.Domain.Interfaces.Domain;

public interface IWorkSummaryService
{
    public Task<string> GenerateDailyWorkSummaryAsync(
        string? organisationName, 
        string authorUsername,
        DateTime date,
        CancellationToken ct);
}