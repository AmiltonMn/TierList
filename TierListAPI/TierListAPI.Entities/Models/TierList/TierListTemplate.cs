namespace TierListAPI.Entitites.Models;

public class TierListTemplate : BaseEntityModel<Guid>
{
    public TierListTemplate() { }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public Guid OwnerId { get; set; }
    public required User Owner { get; set; }
    public bool IsPrivate { get; set; } = false;
    public List<Tier> Tiers { get; } = [];
    public List<Tag> Tags { get; } = [];
}