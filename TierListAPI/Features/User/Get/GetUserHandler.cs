using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.User.Get;

public class GetUserhandler (
    IUserRepository userRepository,
    ITierListTemplateRepository tierListTemplateRepository,
    ISubmissionRepository submissionRepository,
    IMapper mapper
) : IRequestHandler<GetUserRequest, GetUserResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetById(request.UserId, cancellationToken).Result
            ?? throw new NotFoundException(ExceptionMessage.NotFound.User);

        var createdTierLists = tierListTemplateRepository.GetByUserId(request.UserId);

        var answeredTierLists = submissionRepository.GetAllByUserId(request.UserId);

        GetUserResponse userResponse = new (
            Name: user.Name,
            Bio: user.Bio,
            ProfileImage: user.ProfileImage,
            BannerImage: user.BannerImage,
            CreatedTierLists: createdTierLists,
            AnsweredTierLists: answeredTierLists
        );

        return mapper.Map<GetUserResponse>(userResponse);
    }
}