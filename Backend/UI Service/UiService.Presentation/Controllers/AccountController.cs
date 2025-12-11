using Microsoft.AspNetCore.Mvc;
using UiService.Models.Requests;

namespace UiService.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequestDto request)
    {
        await Task.Delay(10);
        return Ok("Account created");
    }
}