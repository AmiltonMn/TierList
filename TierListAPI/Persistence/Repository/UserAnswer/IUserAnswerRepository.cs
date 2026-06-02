using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface IUserAnswerRepository : IRepository<UserAnswer>
{
    List<UserAnswer> GetAllByUserIdAndTemplateId(Guid userId, Guid templateId);
    List<UserAnswer> GetAllByTemplateId(Guid templateId);
    List<UserAnswer> GetAllByTierId(Guid tierId);
    List<UserAnswer> GetAllByUserId(Guid userId);
}