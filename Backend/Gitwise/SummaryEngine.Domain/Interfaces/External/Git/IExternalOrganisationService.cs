using SummaryEngine.Domain.Models;
using SummaryEngine.Domain.Models.WorkSummary;

namespace SummaryEngine.Domain.Interfaces.External.Git;

public interface IExternalOrganisationService
{
    public Task<Organisation> GetOrganisationByNameAsync(string organisationName, CancellationToken ct);
}