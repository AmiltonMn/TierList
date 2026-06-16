using AutoMapper;

namespace TierListAPI.Features.Item.GetAllByTemplate;

public class GetAllByTemplateMapper : Profile
{
    public GetAllByTemplateMapper() 
    {
        CreateMap<GetAllByTemplateRequest, GetAllByTemplateResponse>();    
    }
}
