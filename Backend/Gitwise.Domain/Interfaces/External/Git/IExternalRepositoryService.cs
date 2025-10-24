using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External.Git;

public interface IExternalRepositoryService
{
    public Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct);
}