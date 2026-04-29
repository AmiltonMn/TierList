using TierListAPI.Entities.Models;
using AutoMapper;

namespace TierListAPI.Features.TierListTemplate.Delete;

public class DeleteTierListTemplateMapper : Profile
{
    public DeleteTierListTemplateMapper() 
    {
        CreateMapper<Entities.Models.TierListTemplate, DeleteTierListTemplateResponse>();
    }
}