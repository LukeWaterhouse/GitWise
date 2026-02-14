using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Domain.Interfaces.External.Git;
using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Services;

public class RepositoryService(IExternalRepositoryService externalRepositoryService) : IRepositoryService
{
    public async Task<List<Repository>> GetAllOrgRepositoriesAsync(string organisationName, CancellationToken ct)
    {
        var repos = await externalRepositoryService.GetAllOrganisationRepositoriesAsync(organisationName, ct);
        return repos;
    }
}
