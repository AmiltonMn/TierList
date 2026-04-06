using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

namespace TierListAPI.Entities.Configurations;

public static class TierClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Tier>(builder =>
    {
        builder.ToTable("tb_tiers");

        builder.HasKey(t => t.Id)
            .HasName("tier_id");

        builder.Property(t => t.Label)
            .HasColumnName("label")
            .IsRequired()
            .HasMaxLength(75);

        builder.Property(t => t.Color)
            .HasColumnName("color")
            .IsRequired()
            .HasMaxLength(7);

        builder.Property(t => t.Position)
            .HasColumnName("position")
            .IsRequired();

        builder.Property(t => t.Points)
            .HasColumnName("points")
            .IsRequired();
        
        builder.Property(t => t.TierListId)
            .HasColumnName("tier_list_id")
            .IsRequired();

        builder.HasOne(t => t.TierList)
            .WithMany(tl => tl.Tiers)
            .HasForeignKey(t => t.TierListId)
            .IsRequired();
    });
}