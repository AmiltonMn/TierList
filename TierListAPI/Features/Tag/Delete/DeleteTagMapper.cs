using AutoMapper;

namespace TierListAPI.Features.Tag.Delete;

public class DeleteTagMapper : Profile
{
    public DeleteTagMapper() 
    {
        CreateMap<DeleteTagRequest, DeleteTagResponse>();
    }
}
