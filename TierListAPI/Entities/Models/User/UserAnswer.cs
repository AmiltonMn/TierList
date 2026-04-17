namespace TierListAPI.Entities.Models;

public class UserAnswer : BaseEntityModel
{
    public UserAnswer() { }
    
    public required Guid UserId { get; set; }
    public required User User { get; set; }
    public required Guid TierListId { get; set; }
    public required TierListTemplate TierList { get; set; }
    public required Guid ItemId { get; set; }
    public required Item Item { get; set; }
    public required Guid TierId { get; set; }
    public required Tier Tier { get; set; }
    public string? Comment { get; set; }
}