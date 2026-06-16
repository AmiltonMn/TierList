using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IItemRepository : IRepository<Item>
{
    List<Item> GetByTierListTemplateId(Guid tierListTemplateId); 
    List<Item> GetItemsByName(string name, Guid tierListTemplateId);
    List<Item> GetNotAnsweredItens(Guid tierListTemplateId, Guid UserId);
    List<Item> GetItemsByTier(Guid tierId);
    List<Item> GetItemsByTierAndUser(Guid TierId, Guid UserId);
}