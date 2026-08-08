using AutoMapper;
using MediatR;
using TierListAPI.DTOs;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.User.GetByUsername;

public class GetByUserNameHandler (
    IUserRepository userRepository,
    IMapper mapper
) : IRequestHandler<GetByUserNameRequest, GetByUserNameResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;
    
    public async Task<GetByUserNameResponse> Handle(GetByUserNameRequest request, CancellationToken cancellationToken)
    {
        var users = new List<Entities.Models.User>();
        
        if (request.Name is null)
        {
            users = await userRepository.GetAll(cancellationToken);
        } else
        {
            users = await userRepository.GetAllByUsername(request.Name, cancellationToken);
        }

        var userDtos = mapper.Map<List<UserDto>>(users);

        return new GetByUserNameResponse(userDtos);
    }
}