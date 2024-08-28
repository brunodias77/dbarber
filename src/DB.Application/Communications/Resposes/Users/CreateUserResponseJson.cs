using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Application.Communications.Resposes.Tokens;

namespace DB.Application.Communications.Resposes.Users
{
    public class CreateUserResponseJson
    {
        public string Name { get; set; } = string.Empty;
        public ResponseTokenJson Token { get; set; } = default!;
    }
}