using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DB.Exceptions
{
    public class AuthenticationException : ExceptionBase
    {
        public AuthenticationException(string message) : base(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID)
        {
        }

        public override IList<string> GetErrorMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}