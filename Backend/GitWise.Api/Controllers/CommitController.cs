using GitWise.Api.Mapping;
using Gitwise.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GitWise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommitController(IRepositoryService repositoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCommitsAsync(string organisationName, string repoName, CancellationToken ct)
    {
        var repos = await repositoryService.GetAllOrgRepositoriesAsync(organisationName, ct);
        return Ok(repos.Select(x => x.FromDomain()));
    }
}