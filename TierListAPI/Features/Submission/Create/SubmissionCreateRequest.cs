using MediatR;

namespace TierListAPI.Features.Submission.Create;

public sealed record SubmissionCreateRequest
(
    Guid UserId,
    Guid TierListTemplateId,
    int TemplateVersion
) : IRequest<SubmissionCreateResponse>;
