using TierListAPI.Common.ExceptionMessages;

namespace TierListAPI.Common;

public abstract class AppException : Exception
{
    public int StatusCode { get; }

    protected AppException(string message, int statusCode) : base(message) 
    {
        StatusCode = statusCode;
    }
}

public class UnauthorizedException(string message = ExceptionMessage.Unauthorized.Default) : AppException(message, 401) { }

public class NotFoundException(string message = ExceptionMessage.NotFound.Default) : AppException(message, 404) { }

public class DuplicityException(string message = ExceptionMessage.DuplicityModel.Default) : AppException(message, 409) { }

public class BadRequestException(string message = ExceptionMessage.BadRequest.Default) : AppException(message, 400) { }

public class ForbiddenException(string message = ExceptionMessage.Forbidden.Default) : AppException(message, 403) { }