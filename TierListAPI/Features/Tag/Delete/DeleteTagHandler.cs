using AutoMapper;
using MediatR;
using TagModel = TierListAPI.Entities.Models.Tag;
using TierListAPI.Persistence.Repository;
using TierListAPI.Common;

namespace TierListAPI.Features.Tag.Delete;

public class DeleteTagHandler
(
    ITagRepository tagRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteTagRequest, DeleteTagResponse> {
    public async Task<DeleteTagResponse> Handle(DeleteTagRequest request, CancellationToken cancellationToken) 
    {
        var tag = await tagRepository.GetById(request.TagId, cancellationToken) ?? throw new BadRequestException("Tag inválida.");

        tagRepository.Delete(tag);

        await unitOfWork.Save(cancellationToken);

        return mapper.Map<DeleteTagResponse>(tag);
    }
}
