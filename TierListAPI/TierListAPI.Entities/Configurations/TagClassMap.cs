using Microsoft.EntityFrameworkCore;
using TierListAPI.Entitites.Models;

namespace TierListAPI.Entities.Configurations;
public static class TagClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Tag>(builder =>
    {
        builder.ToTable("tb_tags");

        builder.HasKey(t => t.Id)
            .HasName("tag_id");

        builder.Property(t => t.Label)
            .HasColumnName("label")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Color)
            .HasColumnName("color")
            .IsRequired()
            .HasMaxLength(7);
    });
}