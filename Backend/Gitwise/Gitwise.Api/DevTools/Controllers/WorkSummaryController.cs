using Gitwise.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using SummaryEngine.Domain.Interfaces.Domain;

namespace Gitwise.Api.DevTools.Controllers;

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