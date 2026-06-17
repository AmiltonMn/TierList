using AutoMapper;
using MediatR;
using TierListAPI.Common;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.User.Login;

public class LoginHandler (
    IUserRepository userRepository,
    IMapper mapper
) : IRequestHandler<LoginRequest, LoginResponse>{

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken) 
    {
        var user = userRepository.GetByUsername(request.Username, cancellationToken) ?? throw new NotFoundException("Usuário não encontrado.");


    }
}
