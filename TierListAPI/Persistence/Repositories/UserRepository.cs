using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Context;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class UserRepository(TierListDBContext dBContext)
    : BaseRepository<User>(dBContext), IUserRepository
{
    public Task<List<User>> GetAllByUsername(string username, CancellationToken cancellationToken)
        => context
            .Users
            .Where(u => u.Name.ToLower().Contains(username))
            .ToListAsync(cancellationToken);

    public Task<User> GetByUsername(string username, CancellationToken cancellationToken)
        => context.Users
            .Where(u => u.Name == username)
            .FirstAsync(cancellationToken);
}