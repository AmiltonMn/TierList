namespace API.Controller;

using Microsoft.AspNetCore.Mvc;
using TierListAPI.Entitites.Models;

[ApiController]
[Route("watch/{id}")]
public class UserController(string id)
{
    User user = new User
    {
        Id = new Guid(id),
        Name = "John Doe",
        Bio = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        ProfileImage = "https://example.com/profile.jpg",
        BannerImage = "https://example.com/banner.jpg",
        CreatedAt = DateTimeOffset.UtcNow,
        UpdatedAt = DateTimeOffset.UtcNow,
    };
}