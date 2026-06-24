using MediatR;
using TierListAPI.Common;
using TierListAPI.Persistence.Repository;
using TierListAPI.Services;
using BC = BCrypt.Net.BCrypt;

namespace TierListAPI.Features.User.Login;

public class LoginHandler (
    IUserRepository userRepository,
    IAutheticator authenticator
) : IRequestHandler<LoginRequest, LoginResponse>{

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken) 
    {
        var user = await userRepository.GetByUsername(request.Username, cancellationToken) ?? throw new BadRequestException("Usuário ou senha incorreto(a)");

        if (!BC.Verify(request.Password, user.Password))
            throw new BadRequestException("Usuário ou senha incorreto(a)");

        var token = authenticator.GenerateUserToken(user);

        return new LoginResponse(user.Id, token);
    }
}
