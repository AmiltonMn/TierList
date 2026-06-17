

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TierListAPI.Services;

namespace TierListAPI.Persistence.Context;

public class TierListDBContextFactory : IDesignTimeDbContextFactory<TierListDBContext>
{
    public TierListDBContext CreateDbContext(string[] args)
    {
        DotEnv.Load();

        var optionsBuilder = new DbContextOptionsBuilder<TierListDBContext>();

        optionsBuilder.UseNpgsql(
            DotEnv.Get("DATABASE_URL")
        );

        return new TierListDBContext(optionsBuilder.Options);
    }
}