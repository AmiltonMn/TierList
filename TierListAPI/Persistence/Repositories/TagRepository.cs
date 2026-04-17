using TierListAPI.Persistence.Repository;
using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repositories;

public class TagRepository(TierListDBContext dBContext)
    : BaseRepository<Tag>(dBContext), ITagRepository
{
    public Tag? GetByName(string? name)
        => context
            .Tags
            .FirstOrDefault(t => t.Label == name);
}