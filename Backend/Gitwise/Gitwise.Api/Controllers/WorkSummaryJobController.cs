using ControlPlane.Application.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using Gitwise.Api.Models.Requests;
using Gitwise.Api.Models.Responses;

namespace Gitwise.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkSummaryJobController(IWorkSummaryJobService workSummaryJobService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RequestWorkSummaryJobAsync([FromBody] WorkSummaryJobRequestDto jobRequest, CancellationToken ct)
    {
        if (jobRequest.TenantId == Guid.Empty || jobRequest.DeveloperId == Guid.Empty)
        {
            return BadRequest("Invalid jobRequest payload.");
        }
        
        var jobId = await workSummaryJobService.GetWorkSummaryRequestJobIdAsync(
            jobRequest.TenantId, jobRequest.DeveloperId, jobRequest.SummaryDate, ct);
        
        return Ok(new WorkSummaryJobResponseDto(jobId));
    }
}