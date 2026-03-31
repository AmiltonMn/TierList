namespace TierListAPI.Entitites.Models;

public class Tier : BaseEntityModel<Guid>
{
    public Tier() { }
    
    public required string Label { get; set; }
    public required string Color { get; set; }
    public int Position { get; set; }
    public int Points { get; set; }
    public Guid TierListId { get; set; }
}