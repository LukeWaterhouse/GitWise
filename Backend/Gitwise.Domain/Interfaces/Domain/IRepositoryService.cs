using Gitwise.Domain.Models.Repositories;

namespace Gitwise.Domain.Interfaces.Domain;

public interface IRepositoryService
{
    public Task<List<Repository>> GetAllOrgRepositoriesAsync(string organisationName, CancellationToken ct);
}