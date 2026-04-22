namespace TierListAPI.Entities.Models;

public class Item : BaseEntityModel
{
    public Item() { }
    
    public required string Name { get; set; }
    public required string ItemImage { get; set; }
    public bool IsVertical { get; set; } = true;
    public int Order { get; set; }
    public int Score { get; set; }
    public required Guid TierListId { get; set; }
    public TierListTemplate TierList { get; set; }
    public required Guid TierId { get; set; }
    public Tier Tier { get; set; }
    public List<UserAnswer> UserAnswers {get;} = [];
}