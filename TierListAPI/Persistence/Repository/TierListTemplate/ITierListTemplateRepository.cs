using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface ITierListTemplateRepository : IRepository<TierListTemplate>
{
    List<TierListTemplate> GetByUserId(Guid userId);
    List<TierListTemplate> GetByTagId(Guid tagId);
    List<TierListTemplate> GetPaginatedTiers(int pageNumber, int pageSize, string? searchByName, Guid? tagId, Guid? userId, Guid loggedUserId);
}