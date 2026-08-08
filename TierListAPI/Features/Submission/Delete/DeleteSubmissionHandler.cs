using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Submission.Delete;

public class DeleteSubmissionHandler (
    ISubmissionRepository submissionRepository,
    IUserAnswerRepository userAnswerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteSubmissionRequest, DeleteSubmissionResponse> {

    public async Task<DeleteSubmissionResponse> Handle(DeleteSubmissionRequest request, CancellationToken cancellationToken) 
    {
        if (request.SubmissionId == Guid.Empty)
            throw new NotFoundException(ExceptionMessage.NotFound.Submission);

        await userAnswerRepository.DeleteAllBySubmissionId(request.SubmissionId);

        var submission = submissionRepository.GetById(request.SubmissionId, cancellationToken).Result ?? throw new NotFoundException(ExceptionMessage.NotFound.Submission);

        submissionRepository.Delete(submission);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteSubmissionResponse>(submission);
    }
}
