
using DB.Application.Communications.Requests.Users;
using DB.Application.Communications.Resposes.Users;

namespace DB.Application.UseCases.Users.Create
{
    public interface ICreateUserUseCase
    {
        Task<CreateUserResponseJson> Execute(CreateUserRequestJson request);
    }
}