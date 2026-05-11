using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class BaseRepository<T>(TierListDBContext dBContext) : IRepository<T>
    where T : BaseEntityModel
{
    protected readonly TierListDBContext context = dBContext;
    protected readonly DbSet<T> dbSet = dBContext.Set<T>();

    public void Add(T entity)
        => context
            .Add(entity);

    public void Delete(T entity)
        => context
            .Remove(entity);

    public void Update(T entity)
        => context
            .Update(entity);

    public Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        => dbSet
            .AnyAsync(e => e.Id == id, cancellationToken);

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
        => context
            .Set<T>()
            .ToListAsync(cancellationToken);

    public Task<T?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return context
                .Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }
}