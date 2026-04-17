using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;

public static class UserClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<User>(builder =>
    {
        builder.ToTable("tb_user");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property
            (u => u.Password)
            .HasColumnName("password")
            .IsRequired();

        builder.Property(u => u.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Bio)
            .HasColumnName("bio")
            .HasMaxLength(500);

        builder.Property(u => u.ProfileImage)
            .HasColumnName("profile_image");

        builder.Property(u => u.BannerImage)
            .HasColumnName("banner_image");
    });
}