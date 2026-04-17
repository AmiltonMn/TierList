using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface ITierRepository : IRepository<Tier>
{
    List<Tier> GetTiersByTierListTemplateId(Guid tierListTemplateId);
}