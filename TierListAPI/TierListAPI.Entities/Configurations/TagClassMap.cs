using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

namespace TierListAPI.Entities.Configurations;
public static class TagClassMap
{
    public static void Map(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Label).IsRequired();
            entity.Property(e => e.Color).IsRequired();
        });
    }
}