using TierListAPI.Persistence.Repository;
using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repositories;

public class ItemRepository(TierListDBContext dBContext)
    : BaseRepository<Item>(dBContext), IItemRepository
{
    public List<Item> GetByTierListTemplateId(Guid tierListTemplateId)
        => context
            .Items
            .Where(i => i.TierListId == tierListTemplateId)
            .ToList();

    public List<Item> GetItemsByName(string name)
        => context
            .Items
            .Where(i => i.Name == name)
            .ToList();

    public List<Item> GetNotAnsweredItens(Guid tierListTemplateId, Guid userId)
        => context
            .Items
            .Where(i => i.TierListId == tierListTemplateId)
            .Where(i => !context.UserAnswers.Any(ua => ua.ItemId == i.Id && ua.UserId == userId))
            .ToList();
}