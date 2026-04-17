using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;

namespace TierListAPI.Entities.Configurations;

public static class UserAnswerClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<UserAnswer>(builder =>
        {
            builder.ToTable("tb_userAnswer");

            builder.HasKey(ua => ua.Id);

            builder.Property(ua => ua.UserId)
                .HasColumnName("user_id");

            builder.Property(ua => ua.Comment)
                .HasColumnName("comment")
                .HasMaxLength(500);

            builder.HasOne(ua => ua.User)
                .WithMany(u => u.Answers)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ua => ua.TierId)
                .HasColumnName("tier_id");  

            builder.HasOne(ua => ua.Tier)
                .WithMany(t => t.UserAnswers)
                .HasForeignKey(ua => ua.TierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ua => ua.TierListId)
                .HasColumnName("tierList_id");

            builder.HasOne(ua => ua.TierList)
                .WithMany(tl => tl.UserAnswers)
                .HasForeignKey(ua => ua.TierListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ua => ua.ItemId)
                .HasColumnName("item_id");

            builder.HasOne(ua => ua.Item)
                .WithMany(i => i.UserAnswers)
                .HasForeignKey(ua => ua.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
        });
}