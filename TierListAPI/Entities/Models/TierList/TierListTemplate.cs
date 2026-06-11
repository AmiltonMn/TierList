namespace TierListAPI.Entities.Models;

public class TierListTemplate : BaseEntityModel
{
    public TierListTemplate() { }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string BannerImage { get; set; }
    public required Guid OwnerId { get; set; }
    public int Version { get; set; } = 0;
    public User? Owner { get; set; }
    public bool IsPrivate { get; set; } = false;
    public List<Tier> Tiers { get; set; } = [];
    public List<Tag> Tags { get; set; } = [];
    public List<Item> Items { get; set; } = [];
    public List<TierListSubmission> Submissions { get; set; } = [];
}