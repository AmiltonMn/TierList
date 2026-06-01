using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.Tier.Update;

public class UpdateTierHandler(
    ITierRepository tierRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateTierRequest, UpdateTierResponse>
{ 
    private readonly ITierRepository tierRepository = tierRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;

    public async Task<UpdateTierResponse> Handle(UpdateTierRequest request, CancellationToken cancellationToken) 
    {
        if (request.label)
        {
            
        }
    }
}