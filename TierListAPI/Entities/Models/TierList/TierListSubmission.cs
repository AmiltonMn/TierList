namespace TierListAPI.Entities.Models;

public class TierListSubmission : BaseEntityModel
{
    public required Guid UserId { get; set; }
    public User? User { get; set; }
    public int TemplateVersion { get; set; }
    public DateTimeOffset AnsweredAt { get; set; }
    public required Guid TierListTemplateId { get; set; }
    public TierListTemplate? TierListTemplate { get; set; }
    public List<UserAnswer> Answers { get; set; } = [];
}
