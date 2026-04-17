using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface ITagRepository : IRepository<Tag>
{
    Tag? GetByName(string? name);
}