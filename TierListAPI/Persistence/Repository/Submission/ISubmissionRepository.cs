using TierListAPI.Entities.Models;

namespace TierListAPI.Persistence.Repository;

public interface ISubmissionRepository : IRepository<TierListSubmission> 
{
    List<TierListSubmission> GetAllByUserId(Guid UserId);
}
