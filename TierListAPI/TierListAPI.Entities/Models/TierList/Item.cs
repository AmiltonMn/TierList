namespace TierListAPI.Entitites.Models;

public class Item : BaseEntityModel<Guid>
{
    public Item() { }
    
    public required string Name { get; set; }
    public required string ItemImage { get; set; }
    public bool IsVertical { get; set; } = true;
    public required Guid TierListId { get; set; }
    public TierListTemplate TierList { get; set; }
    public required Guid TierId { get; set; }
    public Tier Tier { get; set; }
}