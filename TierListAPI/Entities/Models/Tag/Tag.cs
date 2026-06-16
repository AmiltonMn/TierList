namespace TierListAPI.Entities.Models;

public class Tag : BaseEntityModel
{   
    public required string Label { get; set; }
    public required string Color { get; set; }
    public List<TierListTemplate> Templates { get; } = [];
}