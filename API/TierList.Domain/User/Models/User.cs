namespace API.TierList.Domain.Models;

public class User : DomainBaseEntity<Guid>
{
    public User() { }
    
    public string Name { get; set; }
    public string Bio { get; set; }
    public string ProfileImage { get; set; }
    public string BannerImage { get; set; }
}