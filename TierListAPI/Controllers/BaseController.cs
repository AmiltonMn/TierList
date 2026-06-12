using Microsoft.AspNetCore.Mvc;

namespace TierListAPI.Controllers;

public abstract class BaseController : ControllerBase
{
    protected Guid GetCurrentUserId()
    {
        var userId = HttpContext.Items["UserId"];
        return userId == null ? throw new Exception("Usuário não autenticado") : (Guid)userId;
    }
}
