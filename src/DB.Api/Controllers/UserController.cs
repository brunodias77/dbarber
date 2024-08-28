using DB.Application.Communications.Requests.Users;
using DB.Application.Communications.Resposes.Users;
using DB.Application.UseCases.Users.Create;
using Microsoft.AspNetCore.Mvc;

namespace DB.Api.Controllers;

[Route("users")]
public class UserController : MainController
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateUserResponseJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromServices] ICreateUserUseCase createUserUseCase, [FromBody] CreateUserRequestJson request)
    {
        var response = await createUserUseCase.Execute(request);
        return Created(string.Empty, response);
    }

}