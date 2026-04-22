using AutoMapper;
using MediatR;
using TierListAPI.Persistence.Repository;
using BC = BCrypt.Net.BCrypt;

namespace TierListAPI.Features.User.Create;

public class CreateUserHandler (
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper
) : IRequestHandler<CreateUserRequest, CreateUserResponse>{
    private readonly IUserRepository userRepository = userRepository;
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IMapper mapper = mapper;
    
    public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var existingUser = await userRepository.GetAllByUsername(request.Name, cancellationToken);

        if (existingUser is not null)
            throw new Exception("Já existe um usuário com esse nome. Escolha outro nome.");

        if (request.Password.Length < 8 && !request.Password.Any(char.IsDigit))
            throw new Exception("A senha deve conter pelo menos 8 caracteres e incluir um número.");
        
        var user = new Entities.Models.User
        {
            Name = request.Name,
            Password = BC.HashPassword(request.Password),
            Bio = request.Bio,
            ProfileImage = request.ProfileImage,
            BannerImage = request.BannerImage
        };

        userRepository.Add(user);
        await unitOfWork.Save(cancellationToken);

        return mapper.Map<CreateUserResponse>(user);
    }
}