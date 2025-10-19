using Gitwise.Domain.Interfaces.Domain;
using Gitwise.Domain.Interfaces.External;
using Gitwise.Domain.Models;

namespace Gitwise.Domain.Services;

public class RepositoryService(IExternalRepositoryService externalRepositoryService) : IRepositoryService
{
    public async Task<List<Repository>> GetAllOrgRepositoriesAsync(string organisationName, CancellationToken ct)
    {
        var repos = await externalRepositoryService.GetAllOrganisationRepositoriesAsync(organisationName, ct);
        return repos;
    }
}
