using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Send;

public sealed record SendAnswersResponse
(
    List<UserAnswerModel> UserAnswers
);
