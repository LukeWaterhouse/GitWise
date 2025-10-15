using Microsoft.AspNetCore.Mvc;

namespace GitWise.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("test")]
    public async Task<IActionResult> GetTestingStuff(CancellationToken ct)
    {
        return Ok("Testing!");
    }
}