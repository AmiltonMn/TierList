

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TierListAPI.Persistence;

public class TierListDBContextFactory : IDesignTimeDbContextFactory<TierListDBContext>
{
    public TierListDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TierListDBContext>();
        // optionsBuilder.UseSqlite("Data Source=TierList.db");
        // TODO: Change to SQL Server

        return new TierListDBContext(optionsBuilder.Options);
    }
}