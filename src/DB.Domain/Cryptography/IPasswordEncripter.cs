using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Domain.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encrypt(string password);
        bool Verify(string password, string passwordHash);
    }
}