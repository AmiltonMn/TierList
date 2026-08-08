using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TierListAPI.Enums;
using TierListAPI.Features.TierListTemplate.Create;
using TierListAPI.Features.TierListTemplate.Delete;

namespace TierListAPI.Controllers;

[ApiController]
[Route(Routes.Template)]
public class TierListTemplateController(IMediator mediator) : BaseController
{
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult<CreateTierListTemplateResponse>> Create([FromBody] CreateTierListTemplateRequest request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }

    [Authorize]
    [HttpPost("delete{id}")]
    public async Task<ActionResult<DeleteTierListTemplateResponse>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeleteTierListTemplateRequest request = new(id, GetCurrentUserId());

        var response = await mediator.Send(request, cancellationToken);

        return Ok(response);
    }
}