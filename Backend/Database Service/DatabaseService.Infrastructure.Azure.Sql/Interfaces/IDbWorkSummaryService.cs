namespace DatabaseService.Infrastructure.Azure.Sql.Interfaces;

public interface IDbWorkSummaryService
{
    public Task CreateWorkSummaryAsync(
        string developerEmail,
        string developerName,
        string tenantName,
        DateOnly date,
        string workSummary);
}