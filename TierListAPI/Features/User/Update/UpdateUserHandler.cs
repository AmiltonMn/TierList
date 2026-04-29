using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;
using UserModel = TierListAPI.Entities.Models.User;

namespace TierListAPI.Features.User.Update;

public class UpdateUserhandler (
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<UpdateUserRequest, UpdateUserResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        UserModel user = userRepository.GetById(request.userId, cancellationToken) 
            ?? throw new Exception("Usuário não encontrado.");

        var existingUser = await userRepository.GetAllByUsername(request.Name, cancellationToken);

        if (existingUser is not null && existingUser.Any(u => u.Id != request.userId))
            throw new Exception("Já existe um usuário com esse nome. Escolha outro nome.");

        user.Name = request.Name;
        user.Bio = request.Bio;
        user.ProfileImage = request.ProfileImage;
        user.BannerImage = request.BannerImage;

        userRepository.Update(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<UpdateUserResponse>(user);
    }
}