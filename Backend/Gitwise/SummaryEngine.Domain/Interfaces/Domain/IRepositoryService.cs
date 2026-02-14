using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.Domain;

public interface IRepositoryService
{
    public Task<List<Repository>> GetAllOrgRepositoriesAsync(string organisationName, CancellationToken ct);
}