using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;
public static class ItemClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Item>(builder =>
    {
        builder.ToTable("tb_items");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Id)
            .HasColumnName("item_id")
            .IsRequired();

        builder.Property(i => i.Name)
            .HasColumnName("name")
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

        builder.HasOne(i => i.TierList)
            .WithMany(tl => tl.Items)
            .HasForeignKey(i => i.TierListId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(i => i.TierId)
            .HasColumnName("tier_id")
            .IsRequired();

        builder.HasOne(i => i.Tier)
            .WithMany(t => t.Items)
            .HasForeignKey(t => t.TierId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();
    });
}