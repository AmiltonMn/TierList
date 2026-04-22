namespace TierListAPI.Entities.Models;

public class TierListTemplate : BaseEntityModel
{
    public TierListTemplate() { }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Guid OwnerId { get; set; }
    public User? Owner { get; set; }
    public bool IsPrivate { get; set; } = false;
    public List<Tier> Tiers { get; } = [];
    public List<Tag> Tags { get; } = [];
    public List<Item> Items { get; } = [];
    public List<UserAnswer> UserAnswers = [];
}