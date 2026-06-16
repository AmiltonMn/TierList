using AutoMapper;

namespace TierListAPI.Features.Tag.Update;

public class UpdateTagMapper : Profile
{
    public UpdateTagMapper() 
    {
        CreateMap<UpdateTagRequest, UpdateTagResponse>();
    }
}
