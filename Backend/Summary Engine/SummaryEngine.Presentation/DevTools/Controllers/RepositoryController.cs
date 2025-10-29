using Microsoft.AspNetCore.Mvc;
using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Presentation.Mapping;

namespace SummaryEngine.Presentation.DevTools.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepositoryController(IRepositoryService repositoryService) : ControllerBase
{
    [HttpGet("{organisationName}")]
    public async Task<IActionResult> GetReposAsync(string organisationName, CancellationToken ct)
    {
        var repos = await repositoryService.GetAllOrgRepositoriesAsync(organisationName, ct);
        return Ok(repos.Select(x => x.FromDomain()));
    }
}