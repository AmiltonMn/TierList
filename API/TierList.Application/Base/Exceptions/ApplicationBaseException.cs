namespace API.TierList.Application.Base.Exceptions;

public class ApplicationBaseException : Exception
{
    public ApplicationBaseException(string message) : base(message) { }
}