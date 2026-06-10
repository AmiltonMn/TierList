namespace TierListAPI.Entities.Models;

public class UserAnswer : BaseEntityModel
{
    public UserAnswer() { }
    
    public required Guid SubmissionId { get; set; }
    public TierListAPI.Entities.Models.TierList.TierListSubmission? Submission { get; set; }
    public required Guid ItemId { get; set; }
    public required Item Item { get; set; }
    public Guid? TierId { get; set; }
    public Tier? Tier { get; set; }
    public required double Score { get; set; }
    public string? Comment { get; set; }
}