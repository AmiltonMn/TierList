using ItemModel = TierListAPI.Entities.Models.Item;

namespace TierListAPI.Features.Item.GetAllByTemplate;

public sealed record GetAllByTemplateResponse
(
    List<ItemModel> Items
);
