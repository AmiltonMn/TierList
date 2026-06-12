using AutoMapper;
using MediatR;
using TierListAPI.DTOs;
using TierListAPI.Persistence.Repository;
using TierListAPI.Persistence.Repository.Submission;

namespace TierListAPI.Features.Submission.GetByUser;

public class GetByUserHandler
(
    ISubmissionRepository submissionRepository,
    IMapper mapper
) : IRequestHandler<GetByUserRequest, GetByUserResponse> {

    public async Task<GetByUserResponse> Handle(GetByUserRequest request, CancellationToken cancellationToken) 
    {
        var submissions = submissionRepository.GetAllByUserId(request.UserId) ?? throw new Exception("Não foi encontrado nenhum grupo de respostas.");

        var userSubmissions = submissions
            .Select(sm => new UserSubmission(sm.TierListTemplate!, sm))
            .ToList();

        return mapper.Map<GetByUserResponse>(userSubmissions);
    }
}
