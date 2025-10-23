using Gitwise.Domain.Models;

namespace Gitwise.Domain.Interfaces.External;

public interface IExternalOrganisationService
{
    public Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct);
}