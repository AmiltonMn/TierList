using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<List<User>> GetAllByUsername(string username, CancellationToken cancellationToken);
    Task<User> GetByUsername(string username, CancellationToken cancellationToken);
}