namespace ControlPlane.Infrastructure.AzureSql.Interfaces;

public interface IDbDeveloperService
{
    public Task CreateDeveloperAsync(string name, string email, string tenantName);
}