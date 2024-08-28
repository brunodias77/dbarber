using DB.Domain.Entities;
using DB.Domain.Repositories;
using DB.Infrastructure.Data;

namespace DB.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task<bool> ExistActiveUserWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistActiveUserWithIdentifier(Guid userId)
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