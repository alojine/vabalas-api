using System.Security.Cryptography;

namespace vabalas_api.Service.Impl
{
    public class PaswordServiceImpl : PasswordService
    {
        public PaswordServiceImpl() { }

        public void CreatePasswordHash (string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
