namespace TierListAPI.Entities.Models;
public class User : BaseEntityModel
{
    public User() { }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public string? Bio { get; set; }
    public string? ProfileImage { get; set; }
    public string? BannerImage { get; set; }
    public List<TierListTemplate> TierListTemplates { get; set; } = [];
    public List<UserAnswer> Answers { get; set; } = [];
}