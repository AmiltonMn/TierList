using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repositories;
using TierListAPI.Persistence.Repository;
using TierListAPI.Persistence.Repository.Submission;
using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Create;

public class CreateUserAnswerHandler (
    IUserAnswerRepository userAnswerRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    ITierRepository tierRepository,
    IUserRepository userRepository,
    IItemRepository itemRepository,
    ISubmissionRepository submissionRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateUserAnswerRequest, CreateUserAnswerResponse> {
    public async Task<CreateUserAnswerResponse> Handle(CreateUserAnswerRequest request, CancellationToken cancellationToken) 
    {
        var tierList = await tierListTemplateRepository.GetById(request.TierListId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.TierListTemplate);

        var tier = await tierRepository.GetById(request.TierId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Tier);
        var user = await userRepository.GetById(request.UserId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.User);
        var item = await itemRepository.GetById(request.ItemId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Default);
        var submission = await submissionRepository.GetById(request.SubmissionId, cancellationToken) ?? throw new NotFoundException(ExceptionMessage.NotFound.Submission);

        var answer = new UserAnswerModel
        {
            SubmissionId = request.SubmissionId,
            TierId = request.TierId,
            Tier = tier,
            ItemId = request.ItemId,
            Item = item,
            Score = 0
        };

        submission.AnsweredAt = DateTimeOffset.UtcNow;
        submission.TemplateVersion = tierList.Version;

        submissionRepository.Update(submission);

        var userAnswersOnTier = userAnswerRepository.GetAllByUserIdAndTierIdAndTemplateId(request.UserId, request.TierListId, request.TierId).Count;

        answer.Score = tier.Points + 1 - (1 / userAnswersOnTier * (request.Order + 1));

        userAnswerRepository.Add(answer);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateUserAnswerResponse>(answer);
    }
}
