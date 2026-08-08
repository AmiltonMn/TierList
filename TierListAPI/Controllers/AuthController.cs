using MediatR;
using Microsoft.AspNetCore.Mvc;
using TierListAPI.Enums;
using TierListAPI.Features.User.Create;
using TierListAPI.Features.User.Login;

namespace TierListAPI.Controllers;

[ApiController]
[Route(Routes.Auth)]
public class AuthController(IMediator mediator) : BaseController
{
    [HttpPost("register")]
    public async Task<ActionResult<CreateUserResponse>> Register([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken) 
    {
        var response = await mediator.Send(request, cancellationToken);
        
        return Ok(response);
    }
}
