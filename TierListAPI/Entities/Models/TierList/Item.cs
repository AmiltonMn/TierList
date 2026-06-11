namespace TierListAPI.Entities.Models;

public class Item : BaseEntityModel
{
    public required string Name { get; set; }
    public required string ItemImage { get; set; }
    public bool IsVertical { get; set; } = true;
    public int Order { get; set; } // Geral
    public double Score { get; set; } // Geral
    public required Guid TierListTemplateId { get; set; }
    public TierListTemplate? TierListTemplate { get; set; }
    public Guid TierId { get; set; }
    public Tier? Tier { get; set; }
    public List<UserAnswer> UserAnswers {get;} = [];
}