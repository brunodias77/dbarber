using DB.Application.Communications.Requests.Appointments;
using DB.Application.Services.Mapper;
using DB.Application.UseCases.Appointments.Create;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DB.Application.Configurations;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCases(services);
        AddMapper(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateAppointmentUseCase, CreateAppointmentUseCase>();

    }
    private static void AddMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
    }

}