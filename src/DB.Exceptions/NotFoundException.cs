using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DB.Exceptions
{
    public class NotFoundException : ExceptionBase
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public override IList<string> GetErrorMessages() => [Message];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
    }
}