using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;

namespace TierListAPI.Features.User.Delete;

public class DeleteUserHandler (
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<DeleteUserRequest, DeleteUserResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        Entities.Models.User user = await userRepository.GetById(request.Id, cancellationToken) 
            ?? throw new Exception("Usuário não encontrado.");

        var DeletedUsers = await userRepository.GetAllByUsername("DeletedUser", cancellationToken);

        user.DeletedAt = DateTimeOffset.Now;
        user.IsDeleted = true;
        user.Name = $"DeletedUser{DeletedUsers.Count}";

        userRepository.Update(user);

        await unitOfWork.Save(cancellationToken);
        
        return mapper.Map<DeleteUserResponse>(user);
    }
}