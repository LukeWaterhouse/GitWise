using GitWise.Api.Mapping;
using GitWise.Api.Models.Requests;
using Gitwise.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GitWise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommitsController(ICommitService commitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetCommitsAsync([FromBody] GetCommitsRequestDto request, CancellationToken ct)
    {
        var repoCommits = await commitService.GetAllRepoCommitsAsync(
            request.OrganisationName,
            request.AuthorEmail,
            request.Date,
            ct);
        
        var response = repoCommits.ToDictionary(
            x => x.Key,
            x => x.Value.Select(c => c.FromDomain()).ToList());
        
        return Ok(response);
    }
}