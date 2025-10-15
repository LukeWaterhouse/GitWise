using Gitwise.Domain.Models;
using Gitwise.Domain.Models.Repositories;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalRepositoryService
{
    public Task<List<Repository>> GetAllOrganisationRepositoriesAsync(string organisationName, CancellationToken ct);
}