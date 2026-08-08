
using MediatR;
using Microsoft.AspNetCore.Mvc;

using TierListAPI.Common;
using TierListAPI.Common.ExceptionMessages;
using TierListAPI.Enums;
using TierListAPI.Features.User.Delete;
using TierListAPI.Features.User.Get;
using TierListAPI.Features.User.GetByUsername;
using TierListAPI.Features.User.Update;

namespace TierListAPI.Controllers;

[ApiController]
[Route(Routes.User)]
public class UserController(IMediator mediator) : BaseController
{
    [HttpPut("update")]
    public async Task<ActionResult<UpdateUserResponse>> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken) 
    {
        GetCurrentUserId();
        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<DeleteUserResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        if (GetCurrentUserId() != id)
            throw new UnauthorizedException(ExceptionMessage.Unauthorized.Default);

        DeleteUserRequest request = new(id);

        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<GetUserResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken) 
    {
        GetUserRequest request = new(id);
        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [HttpGet("users/{username}")]
    public async Task<ActionResult<GetByUserNameResponse>> GetByusername([FromRoute] string username, CancellationToken cancellationToken)
    {
        GetByUserNameRequest request = new(username);
        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}