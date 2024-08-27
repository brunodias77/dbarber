using DB.Domain.Entities;
using DB.Domain.Repositories;

namespace DB.Infrastructure.Repositories;

public class UserRepository: IUserRepository
{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}