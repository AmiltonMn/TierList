using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.User.Get;

public class GetUserhandler (
    IUserRepository userRepository,
    IMapper mapper
) : IRequestHandler<GetUserRequest, GetUserResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IMapper mapper = mapper;
    
    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = userRepository.GetById(request.UserId, cancellationToken) 
            ?? throw new Exception("Usuário não encontrado.");

        return mapper.Map<GetUserResponse>(user);
    }
}