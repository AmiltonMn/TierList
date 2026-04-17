using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;
public static class TagClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<Tag>(builder =>
    {
        builder.ToTable("tb_tags");

        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.Id)
            .HasColumnName("tag_id")
            .IsRequired();

        builder.Property(t => t.Label)
            .HasColumnName("label")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.Color)
            .HasColumnName("color")
            .IsRequired()
            .HasMaxLength(7);

        builder.HasMany(t => t.Templates)
            .WithMany(t => t.Tags)
            .UsingEntity(j => j.ToTable("tb_template_tags"));
    });
}