namespace TierListAPI.Entitites.Models;
public class User : BaseEntityModel<Guid> 
{
    public User() { }
    public required string Name { get; set; }
    public string? Bio { get; set; }
    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }
    public ICollection<TierListTemplate> TierListTemplates { get; set; } = [];
}