using TierListAPI.Entities.Models;

namespace TierListAPI.DTOs;

public sealed record UserDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Bio { get; set; } = string.Empty;
    public string? ProfileImage { get; set; } = string.Empty;
    public string? BannerImage { get; set; } = string.Empty;
    public List<TierListTemplate> CreatedTierLists { get; set; } = [];
    public List<TierListSubmission> Submissions { get; set; } = [];
}
