using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IItemRepository : IRepository<Item>
{
    List<Item> GetByTierListTemplateId(Guid tierListTemplateId); 
    List<Item> GetItemsByName(string name);
    List<Item> GetNotAnsweredItens(Guid tierListTemplateId, Guid UserId);
}