using DB.Application.Communications.Requests.Appointments;
using DB.Application.Dtos;

namespace DB.Application.UseCases.Appointments.Create;

public class CreateAppointmentUseCase : ICreateAppointmentUseCase
{
    public Task<AppointmentDTO> Execute(CreateAppointmentRequestJson request)
    {
        throw new NotImplementedException();
    }
}