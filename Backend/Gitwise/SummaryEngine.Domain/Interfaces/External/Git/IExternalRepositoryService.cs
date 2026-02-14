using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.External.Git;

public interface IExternalRepositoryService
{
    public Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct);
}