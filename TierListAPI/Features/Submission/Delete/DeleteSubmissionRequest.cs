using MediatR;

namespace TierListAPI.Features.Submission.Delete;

public sealed record DeleteSubmissionRequest
(
    Guid SubmissionId
) : IRequest<DeleteSubmissionResponse>;
