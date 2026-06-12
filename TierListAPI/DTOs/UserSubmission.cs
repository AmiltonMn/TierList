using TierListAPI.Entities.Models;

namespace TierListAPI.DTOs;

public record class UserSubmission
(
    TierListTemplate TierListTemplate,
    TierListSubmission Submission
);