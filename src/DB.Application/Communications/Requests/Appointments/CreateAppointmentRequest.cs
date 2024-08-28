namespace DB.Application.Communications.Requests.Appointments;

public class CreateAppointmentRequestJson
{
    public Guid ProviderId { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
}