

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TierListAPI.Persistence;

public class TierListDBContextFactory : IDesignTimeDbContextFactory<TierListDBContext>
{
    public TierListDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TierListDBContext>();

        optionsBuilder.

        return new TierListDBContext(optionsBuilder.Options);
    }
}