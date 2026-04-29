using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.TierListTemplate.GetByQuery;

public class GetTirListTemplateMapper : Profile
{
    public GetTirListTemplateMapper()
    {
        CreateMap<Entities.Models.TierListTemplate, GetByQueryTierListTemplateResponse>();
    }
}