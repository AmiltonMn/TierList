using ItemModel = TierListAPI.Entities.Models.Item;

namespace TierListAPI.Features.Item.GetByTier;

public sealed record GetItemByTierResponse
(
    List<ItemModel> Items
);