using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class UserAnswerRepository(TierListDBContext dBContext)
    : BaseRepository<UserAnswer>(dBContext), IUserAnswerRepository
{
    public List<UserAnswer> GetAllByTemplateId(Guid templateId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.Submission!.TierListTemplateId == templateId)];

    public List<UserAnswer> GetAllByUserId(Guid userId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.Submission!.UserId == userId)];

    public List<UserAnswer> GetAllByUserIdAndTemplateId(Guid userId, Guid templateId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.Submission!.UserId == userId && ua.Submission!.TierListTemplateId == templateId)];

    public List<UserAnswer> GetAllByTierId(Guid tierId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.TierId == tierId)];

    public List<UserAnswer> GetAllByUserIdAndTierIdAndTemplateId(Guid userId, Guid templateId, Guid? tierId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.Submission!.UserId == userId && ua.TierId == tierId && ua.Submission!.TierListTemplateId == templateId)];

    public List<UserAnswer> GetAllByItemId(Guid itemId)
        => [.. context
            .UserAnswers
            .Where(ua => ua.ItemId == itemId)];

    public async Task<int> DeleteAllBySubmissionId(Guid submissionId)
    {
        return await 
            context
            .UserAnswers
            .Where(ua => ua.SubmissionId == submissionId)
            .ExecuteDeleteAsync();
    }
}