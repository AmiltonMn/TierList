using ItemModel = TierListAPI.Entities.Models.Item;

namespace TierListAPI.Features.Item.Get;

public sealed record GetItemResponse
(
    ItemModel Item
);
