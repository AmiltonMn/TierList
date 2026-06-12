using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;
using SubmissionModel = TierListAPI.Entities.Models.TierListSubmission;
using TierListAPI.Persistence.Repository.Submission;

namespace TierListAPI.Features.Submission.Create;

public class SubmissionCreateHandler 
(
    ISubmissionRepository submissionRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<SubmissionCreateRequest, SubmissionCreateResponse> {

    public async Task<SubmissionCreateResponse> Handle(SubmissionCreateRequest request, CancellationToken cancellationToken) 
    {
        if (request.TierListTemplateId == Guid.Empty || request.UserId == Guid.Empty)
            throw new Exception("Dados insuficientes para criar um grupo de respostas.");

        var submission = new SubmissionModel
        {
            TierListTemplateId = request.TierListTemplateId,
            UserId = request.UserId,
            TemplateVersion = request.TemplateVersion
        };

        submissionRepository.Add(submission);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<SubmissionCreateResponse>(submission);
    }
}
