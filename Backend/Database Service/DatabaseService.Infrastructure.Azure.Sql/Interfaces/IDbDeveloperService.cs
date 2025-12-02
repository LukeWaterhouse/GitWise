using DatabaseService.Infrastructure.Azure.Sql.EfCore.Models;

namespace DatabaseService.Infrastructure.Azure.Sql.Interfaces;

public interface IDbDeveloperService
{
    public Task CreateDeveloperAsync(string name, string email, string tenantName);
}