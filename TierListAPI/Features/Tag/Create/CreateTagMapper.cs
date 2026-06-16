using AutoMapper;

namespace TierListAPI.Features.Tag.Create;

public class CreateTagMapper : Profile
{
    public CreateTagMapper() 
    {
        CreateMap<CreateTagRequest, CreateTagResponse>();
    }
}
