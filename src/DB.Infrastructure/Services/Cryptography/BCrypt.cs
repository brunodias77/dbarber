using DB.Domain.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace DB.Infrastructure.Services.Cryptography
{
    public class BCrypt : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool Verify(string password, string passwordHash) => BC.Verify(password, passwordHash);

    }
}