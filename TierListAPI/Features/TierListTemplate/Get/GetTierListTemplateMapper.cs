using AutoMapper;

namespace TierListAPI.Features.TierListTemplate.Get;

public class GetTirListTemplateMapper : Profile
{
    public GetTirListTemplateMapper()
    {
        CreateMap<Entities.Models.TierListTemplate, GetByQueryTierListTemplateResponse>();
    }
}