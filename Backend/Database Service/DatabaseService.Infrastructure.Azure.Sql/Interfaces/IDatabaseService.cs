namespace DatabaseService.Infrastructure.Azure.Sql.Interfaces;

public interface IDatabaseService
{
    public Task<bool> CreateTenantIfNotExistsAsync(string tenantName);
}