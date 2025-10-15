using Microsoft.AspNetCore.Mvc;

namespace GitWise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReposController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetReposAsync(CancellationToken ct)
    {
        return Ok("Repos");
    }
}