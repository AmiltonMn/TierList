using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

namespace TierListAPI.Entities.Configurations;
public static class ItemClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Item>(builder =>
    {
        builder.ToTable("tb_items");

        builder.HasKey(i => i.Id)
            .HasName("item_id");

        builder.Property(i => i.Name)
            .HasColumnName("ame")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.ItemImage)
            .HasColumnName("item_image")
            .IsRequired();

        builder.Property(i => i.IsVertical)
            .HasColumnName("is_vertical")
            .IsRequired();
        
        builder.Property(i => i.TierListId)
            .HasColumnName("tier_list_id")
            .IsRequired();

        builder.Property(i => i.TierId)
            .HasColumnName("tier_id")
            .IsRequired();

        builder.HasOne(i => i.Tier)
            .WithMany(t => t.Items)
            .HasForeignKey(t => t.TierId)
            .IsRequired();
    });
}