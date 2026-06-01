namespace TierListAPI.Entities.Models;

public class Tier : BaseEntityModel
{
    public Tier() { }
    
    public required string Label { get; set; }
    public required string Color { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }
    public required Guid TierListId { get; set; }
    public TierListTemplate TierList { get; set; }
    public List<Item> Items { get; } = [];
    public List<UserAnswer> UserAnswers { get; } = [];
}