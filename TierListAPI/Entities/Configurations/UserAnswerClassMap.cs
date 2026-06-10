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

            builder.Property(ua => ua.SubmissionId)
                .HasColumnName("submission_id");

            builder.HasOne(ua => ua.Submission)
                .WithMany(s => s.Answers)
                .HasForeignKey(ua => ua.SubmissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ua => ua.Comment)
                .HasColumnName("comment")
                .HasMaxLength(500);

            builder.Property(ua => ua.TierId)
                .HasColumnName("tier_id")
                .IsRequired(false);  

            builder.HasOne(ua => ua.Tier)
                .WithMany(t => t.UserAnswers)
                .HasForeignKey(ua => ua.TierId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(ua => ua.ItemId)
                .HasColumnName("item_id");

            builder.HasOne(ua => ua.Item)
                .WithMany(i => i.UserAnswers)
                .HasForeignKey(ua => ua.ItemId)
                .OnDelete(DeleteBehavior.NoAction);
        });
}