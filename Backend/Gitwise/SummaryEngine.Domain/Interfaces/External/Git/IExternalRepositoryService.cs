using SummaryEngine.Domain.Models;

namespace SummaryEngine.Domain.Interfaces.External.Git;

public interface IExternalRepositoryService
{
    public Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct);
}