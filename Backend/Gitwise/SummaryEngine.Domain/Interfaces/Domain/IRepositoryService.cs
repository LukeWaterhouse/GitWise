using SummaryEngine.Domain.Models;

namespace SummaryEngine.Domain.Interfaces.Domain;

public interface IRepositoryService
{
    public Task<List<Repository>> GetAllOrgRepositoriesAsync(string organisationName, CancellationToken ct);
}