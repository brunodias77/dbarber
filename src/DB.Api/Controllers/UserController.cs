using Microsoft.AspNetCore.Mvc;

namespace DB.Api.Controllers;

[Microsoft.AspNetCore.Components.Route("users")]
public class UserController : MainController
{
    [HttpGet]
    public async Task<IActionResult> Teste()
    {
        return Ok("Ok Google");
    }
}