using Microsoft.EntityFrameworkCore;
using TierListAPI.Entities.Models;
using TierListAPI.Persistence.Context;
using TierListAPI.Persistence.Repository.Submission;

namespace TierListAPI.Persistence.Repositories;

public class SubmissionRepository(TierListDBContext dBContext)
    : BaseRepository<TierListSubmission>(dBContext), ISubmissionRepository
{
    public List<TierListSubmission> GetAllByUserId(Guid UserId)
        => [.. context
            .TierListSubmission
            .Include (t => t.TierListTemplate)
            .Where(s => s.UserId == UserId)];
}
