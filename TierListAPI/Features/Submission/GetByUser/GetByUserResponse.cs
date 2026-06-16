using TierListAPI.DTOs;

namespace TierListAPI.Features.Submission.GetByUser;

public sealed record GetByUserResponse
(
    List<UserSubmission> UserSubmission
);
