namespace TierListAPI;

using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

public class TierListDBContext(DbContextOptions<TierListDBContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TierListTemplate> TierListTemplates { get; set; }
    public DbSet<Tier> Tiers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .HasMany(u => u.TierListTemplates)
            .WithOne(t => t.Owner)
            .HasForeignKey(t => t.OwnerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}