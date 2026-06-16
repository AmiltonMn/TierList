using AutoMapper;

namespace TierListAPI.Features.Tag.GetAll;

public class GetAllTagMapper : Profile
{
    public GetAllTagMapper() 
    {
        CreateMap<GetAllTagRequest, GetAllTagResponse>();
    }
}
