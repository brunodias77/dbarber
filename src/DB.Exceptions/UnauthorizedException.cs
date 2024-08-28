using System.Net;

namespace DB.Exceptions;

public class UnauthorizedException : ExceptionBase
{
    public UnauthorizedException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages()
    {
        return [Message];
    }

    public override HttpStatusCode GetStatusCode()
    {
        return HttpStatusCode.Unauthorized;
    }
}