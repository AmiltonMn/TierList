using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.GetAllByTemplateAndUser;

public sealed record GetAllByTemplateAndUserResponse
(
    List<UserAnswerModel> UserAnswers
);
