using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;

public static class TierListTemplateClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<TierListTemplate>(builder =>
    {
        builder.ToTable("tb_tier_list_templates");

        builder.HasKey(tlt => tlt.Id);

        builder.Property(tlt => tlt.Id)
            .HasColumnName("tierListTemplate_id")
            .IsRequired();

        builder.Property(tlt => tlt.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(tlt => tlt.Description)
            .HasColumnName("description")
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(tlt => tlt.OwnerId)
            .HasColumnName("owner_id")
            .IsRequired();

        builder.HasOne(tlt => tlt.Owner)
            .WithMany(u => u.TierListTemplates)
            .HasForeignKey(tlt => tlt.OwnerId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.Property(tlt => tlt.IsPrivate)
            .HasColumnName("is_private")
            .IsRequired();
    });
}