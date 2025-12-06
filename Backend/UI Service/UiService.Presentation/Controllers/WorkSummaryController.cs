using Microsoft.AspNetCore.Mvc;
using UiService.Models.Requests;

namespace UiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSummaryController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessWorkSummaryAsync([FromBody] ProcessCommitsRequestDto request, CancellationToken ct)
    {
        return Ok();
    }

    [HttpGet("{organisationName}/{authorUsername}/{date}")]
    public async Task<IActionResult> GetWorkSummaryAsync(string organisationName, string authorUsername, DateOnly date,
        CancellationToken ct)
    {
        await Task.Delay(10, ct);
        return Ok("Here is the work summary");
    }
}