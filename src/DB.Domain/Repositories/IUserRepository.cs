using DB.Domain.Entities;

namespace DB.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User> GetById(Guid id);
    Task<User?> GetUserByEmail(string email);
}