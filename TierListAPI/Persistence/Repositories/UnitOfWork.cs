using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class UnitOfWork(TierListDBContext context) : IUnitOfWork
{
    public async Task Save(CancellationToken cancellationToken)
    {
        await context.SaveChangesAsync();
    }
}
