using GitWise.Api.Models.Requests;
using Gitwise.Domain.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GitWise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSummaryController(IWorkSummaryService workSummaryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> GetReposAsync([FromBody] GetCommitsRequestDto request, CancellationToken ct)
    {
        var work = await workSummaryService.GenerateDailyWorkSummaryAsync(
            request.OrganisationName, 
            request.AuthorUsername, 
            request.Date, ct);

        return Ok(work);
    }
}