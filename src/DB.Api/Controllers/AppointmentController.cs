using DB.Api.Attributes;
using DB.Application.Communications.Requests.Appointments;
using DB.Application.Communications.Resposes.Errors;
using DB.Application.UseCases.Appointments.Create;
using Microsoft.AspNetCore.Mvc;

namespace DB.Api.Controllers;

[Route("appointments")]
[AuthenticatedUser]
public class AppointmentController : MainController
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAppoitment([FromServices] ICreateAppointmentUseCase useCase,
        [FromBody] CreateAppointmentRequestJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}