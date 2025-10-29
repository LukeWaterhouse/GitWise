using Microsoft.AspNetCore.Mvc;
using SummaryEngine.Domain.Interfaces.Domain;
using SummaryEngine.Presentation.Mapping;
using SummaryEngine.Presentation.Models.Requests;

namespace SummaryEngine.Presentation.DevTools.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommitsController(ICommitService commitService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetCommitsAsync([FromBody] GetCommitsRequestDto request, CancellationToken ct)
    {
        var repoCommits = await commitService.GetDailyRepoCommitsByUserAsync(
            request.OrganisationName,
            request.AuthorUsername,
            request.Date,
            ct);
        
        var response = repoCommits.ToDictionary(
            x => x.Key,
            x => x.Value.Select(c => c.FromDomain()).ToList());
        
        return Ok(response);
    }
}