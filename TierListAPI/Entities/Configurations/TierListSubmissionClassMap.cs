using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models.TierList;

namespace TierListAPI.Entities.Configurations;

public static class TierListSubmissionClassMap
{
    public static void Map(this ModelBuilder modelBuilder)
        => modelBuilder.Entity<TierListSubmission>(builder =>
        {
            builder.ToTable("tb_tierListSubmission");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.UserId)
                .HasColumnName("user_id");

            builder.HasOne(s => s.User)
                .WithMany(u => u.Submissions)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.TierListTemplateId)
                .HasColumnName("tierListTemplate_id");

            builder.HasOne(s => s.TierListTemplate)
                .WithMany(t => t.Submissions)
                .HasForeignKey(s => s.TierListTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        });
}
