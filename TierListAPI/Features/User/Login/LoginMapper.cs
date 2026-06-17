using AutoMapper;

namespace TierListAPI.Features.User.Login;

public class LoginMapper : Profile
{
    public LoginMapper() 
    {
        CreateMap<LoginRequest, LoginResponse>();
    }
}
