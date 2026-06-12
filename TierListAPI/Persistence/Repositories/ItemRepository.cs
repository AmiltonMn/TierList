using TierListAPI.Persistence.Repository;
using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repositories;

public class ItemRepository(TierListDBContext dBContext)
    : BaseRepository<Item>(dBContext), IItemRepository
{
    public List<Item> GetByTierListTemplateId(Guid tierListTemplateId)
        => [.. context
            .Items
            .Where(i => i.TierListTemplateId == tierListTemplateId)];

    public List<Item> GetItemsByName(string name, Guid tierListTemplateId)
        => [.. context
            .Items
            .Where(i => i.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase) && i.TierListTemplateId == tierListTemplateId)];

    public List<Item> GetItemsByTier(Guid tierId)
        => [.. context
            .Items
            .Where(i => i.TierId == tierId)];
    public List<Item> GetItemsByTierAndUser(Guid TierId, Guid UserId)
        => [.. context
            .Items
            .Where(i => context.UserAnswers.Any(ua => ua.TierId == TierId && ua.ItemId == i.Id))];

    public List<Item> GetNotAnsweredItens(Guid tierListTemplateId, Guid userId)
        => [.. context
            .Items
            .Where(i => !context.UserAnswers.Any(ua => ua.ItemId == i.Id && ua.Submission!.UserId == userId))];

    
}