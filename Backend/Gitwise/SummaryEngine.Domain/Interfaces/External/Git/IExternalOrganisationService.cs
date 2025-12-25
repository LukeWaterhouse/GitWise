using SummaryEngine.Domain.Models;

namespace SummaryEngine.Domain.Interfaces.External.Git;

public interface IExternalOrganisationService
{
    public Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct);
}