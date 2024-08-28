namespace DB.Application.Dtos;

public record AppointmentDTO(
    Guid ProviderId,
    Guid UserId,
    DateTime Date,
    string ProviderName,
    string UserName
);