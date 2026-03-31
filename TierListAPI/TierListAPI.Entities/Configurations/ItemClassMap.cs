using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

namespace TierListAPI.Entities.Configurations;
public static class ItemClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Item>(builder =>
    {
        builder.HasKey(i => i.Id)
            .HasName("itemId");

        builder.ToTable("tb_items");

        builder.Property(i => i.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(i => i.ItemImage)
            .IsRequired();
    });
}