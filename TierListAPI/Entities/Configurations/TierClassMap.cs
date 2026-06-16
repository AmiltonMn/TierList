using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;

public static class TierClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Tier>(builder =>
    {
        builder.ToTable("tb_tiers");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .HasColumnName("tier_id")
            .IsRequired();

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
        
        builder.Property(t => t.TierListTemplateId)
            .HasColumnName("tier_list_id")
            .IsRequired();

        builder.HasOne(t => t.TierListTemplate)
            .WithMany(tl => tl.Tiers)
            .HasForeignKey(t => t.TierListTemplateId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasMany(t => t.Items)
            .WithOne(i => i.Tier)
            .HasForeignKey(i => i.TierId)
            .IsRequired(false);
    });
}