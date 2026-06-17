using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TierListAPI.Controllers;

public abstract class BaseController : ControllerBase
{
    protected Guid GetCurrentUserId()
    {
        var userIdString = HttpContext.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
        {
            throw new UnauthorizedAccessException("Usuário não autenticado");
        }

        return userId;
    }
}
