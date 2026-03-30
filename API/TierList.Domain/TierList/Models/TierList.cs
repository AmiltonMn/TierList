namespace API.TierList.Domain.Models;

public class TierList : DomainBaseEntity<Guid>
{
    public TierList() { }
    
    public string Name { get; set; }
    public string Description { get; set; }
    public User Owner { get; set; }
    public bool IsPrivate { get; set; }
}