namespace TierListAPI.Entitites.Models;

public class Tag : BaseEntityModel<Guid>
{
    public Tag() { }
    
    public required string Label { get; set; }
    public required string Color { get; set; }
}