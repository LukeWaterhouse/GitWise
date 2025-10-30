using ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSummaryController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> ProcessWorkSummaryAsync([FromBody] ProcessCommitsRequestDto request, CancellationToken ct)
    {
        return Ok();
    }
}