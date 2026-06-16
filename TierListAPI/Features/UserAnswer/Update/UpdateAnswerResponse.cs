using UserAnswerModel = TierListAPI.Entities.Models.UserAnswer;

namespace TierListAPI.Features.UserAnswer.Update;

public sealed record UpdateAnswerResponse
(
    UserAnswerModel UpdatedAnswer
);