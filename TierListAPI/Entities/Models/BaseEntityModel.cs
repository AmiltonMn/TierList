namespace TierListAPI.Entities.Models;

public class BaseEntityModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public Boolean? IsDeleted { get; set; } = false;
}