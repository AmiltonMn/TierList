using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.TierListTemplate.Create;

public class CreateTirListTemplateMapper : Profile
{
    public CreateTirListTemplateMapper()
    {
        CreateMap<Entities.Models.TierListTemplate, CreateTierListTemplateResponse>();
    }
}