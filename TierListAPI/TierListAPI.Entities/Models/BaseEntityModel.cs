namespace TierListAPI.Entitites;

public class BaseEntityModel<T>
{
    public required T Id { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}