using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Persistence.Repositories;

public class UserAnswerRepository(TierListDBContext dBContext)
    : BaseRepository<UserAnswer>(dBContext), IUserAnswerRepository
{
    public List<UserAnswer> GetAllByTemplateId(Guid templateId)
        => context
            .UserAnswers
            .Where(ua => ua.Id == templateId)
            .ToList();

    public List<UserAnswer> GetAllByUserId(Guid userId)
        => context
            .UserAnswers
            .Where(ua => ua.UserId == userId)
            .ToList();

    public List<UserAnswer> GetAllByUserIdAndTemplateId(Guid userId, Guid templateId)
        => context
            .UserAnswers
            .Where(ua => ua.UserId == userId && ua.Id == templateId)
            .ToList();
}