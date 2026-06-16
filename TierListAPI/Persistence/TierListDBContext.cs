namespace TierListAPI.Persistence;

using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Entities.Models.TierList;
using TierListAPI.Entities.Configurations;

public class TierListDBContext(DbContextOptions<TierListDBContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TierListTemplate> TierListTemplates { get; set; }
    public DbSet<Tier> Tiers { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<TierListSubmission> TierListSubmissions { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        UserClassMap.Map(modelBuilder);
        TierListTemplateClassMap.Map(modelBuilder);
        TierClassMap.Map(modelBuilder);
        ItemClassMap.Map(modelBuilder);
        TierListSubmissionClassMap.Map(modelBuilder);
        UserAnswerClassMap.Map(modelBuilder);
        TagClassMap.Map(modelBuilder);
    }
}