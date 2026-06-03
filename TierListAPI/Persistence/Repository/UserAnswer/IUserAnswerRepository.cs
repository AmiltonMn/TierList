using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IUserAnswerRepository : IRepository<UserAnswer>
{
    List<UserAnswer> GetAllByUserIdAndTemplateId(Guid userId, Guid templateId);
    List<UserAnswer> GetAllByUserIdAndTierIdAndTemplateId(Guid userId, Guid templateId, Guid tierId);
    List<UserAnswer> GetAllByTemplateId(Guid templateId);
    List<UserAnswer> GetAllByItemId(Guid itemId);
    List<UserAnswer> GetAllByTierId(Guid tierId);
    List<UserAnswer> GetAllByUserId(Guid userId);
}