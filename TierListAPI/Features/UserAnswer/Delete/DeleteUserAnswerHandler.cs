using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.UserAnswer.Delete;

public class DeleteUserAnswerHandler (
    IUserAnswerRepository userAnswerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteUserAnswerRequest, DeleteUserAnswerResponse> {
    private readonly IUserAnswerRepository userAnswerRepository = userAnswerRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<DeleteUserAnswerResponse> Handle(DeleteUserAnswerRequest request, CancellationToken cancellationToken)
    {
        var userAnswer = await userAnswerRepository.GetById(request.AnswerId, cancellationToken) ?? throw new Exception("Resposta não encontrada.");

        userAnswerRepository.Delete(userAnswer);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteUserAnswerResponse>(userAnswer);
    }
}
