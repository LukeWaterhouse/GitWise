using GitWise.Api.Mapping;
using Gitwise.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GitWise.Api.Controllers;

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