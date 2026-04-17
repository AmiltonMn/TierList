using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class TierListTemplateRepository(TierListDBContext dBContext)
    : BaseRepository<TierListTemplate>(dBContext), ITierListTemplateRepository
{
    public List<TierListTemplate> GetByTagId(Guid tagId)
        => context
            .TierListTemplates
            .Where(tlt => tlt.Tags.Any(t => t.Id == tagId))
            .ToList();

    public List<TierListTemplate> GetByUserId(Guid userId)
        => context
            .TierListTemplates
            .Where(tlt => tlt.OwnerId == userId)
            .ToList();

    public List<TierListTemplate> GetPaginatedTiers(int pageNumber, int pageSize, string? searchByName, Guid? tagId, Guid? userId)
    {
        var query = context
            .TierListTemplates
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchByName))
            query = query.Where(tlt => tlt.Name.Contains(searchByName));

        if (tagId.HasValue)
            query = query.Where(tlt => tlt.Tags.Any(t => t.Id == tagId.Value));

        if (userId.HasValue)
            query = query.Where(tlt => tlt.OwnerId == userId.Value);

        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }
}