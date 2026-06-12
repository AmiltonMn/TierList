using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;
using TierListAPI.Persistence.Repository.Submission;

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
            throw new Exception("Grupo de respostas não encontrado.");

        await userAnswerRepository.DeleteAllBySubmissionId(request.SubmissionId);

        var submission = submissionRepository.GetById(request.SubmissionId, cancellationToken).Result ?? throw new Exception("Grupo de respostas não encontrado no banco.");

        submissionRepository.Delete(submission);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteSubmissionResponse>(submission);
    }
}
