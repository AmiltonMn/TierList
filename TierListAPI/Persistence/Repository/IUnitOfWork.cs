namespace TierListAPI.Persistence.Repository;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}