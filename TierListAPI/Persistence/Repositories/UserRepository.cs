using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class UserRepository(TierListDBContext dBContext)
    : BaseRepository<User>(dBContext), IUserRepository
{
    public Task<List<User>> GetAllByUsername(string username, CancellationToken cancellationToken)
        => context
            .Users
            .Where(u => u.Name.Contains(username, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync(cancellationToken);
}