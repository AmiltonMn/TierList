using TierListAPI.Persistence.Repository;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Context;

namespace TierListAPI.Persistence.Repositories;

public class TagRepository(TierListDBContext dBContext)
    : BaseRepository<Tag>(dBContext), ITagRepository
{
    public Tag? GetByName(string? name)
        => context
            .Tags
            .FirstOrDefault(t => name == null || t.Label.Contains(name, StringComparison.CurrentCultureIgnoreCase));
}