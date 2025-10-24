using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External.Git;

public interface IExternalOrganisationService
{
    public Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct);
}