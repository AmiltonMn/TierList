using TierListAPI.Persistence.Repository;
using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repositories;

public class TierRepository(TierListDBContext dBContext)
    : BaseRepository<Tier>(dBContext), ITierRepository
{
    public List<Tier> GetTiersByTierListTemplateId(Guid tierListTemplateId)
        => context
            .Tiers
            .Where(t => t.TierListId == tierListTemplateId)
            .ToList();
}