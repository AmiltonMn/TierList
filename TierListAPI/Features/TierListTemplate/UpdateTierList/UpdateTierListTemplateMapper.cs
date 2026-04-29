using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.TierListTemplate.Update;

public class UpdateTierListTemplateMapper : Profile
{
    public UpdateTierListTemplateMapper() 
    {
        CreateMap<Entities.Models.TierListTemplate, UpdateTierListTemplateResponse>();
    }
}