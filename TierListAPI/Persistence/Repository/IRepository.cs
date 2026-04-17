using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IRepository<T> 
    where T : BaseEntityModel
{
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);
    Task<bool> Exists(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}