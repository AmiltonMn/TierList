using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.GetAllByItem;

public sealed record GetAllByTierAndUserResponse
(
    List<UserAnswerModel> UserAnswers
);
