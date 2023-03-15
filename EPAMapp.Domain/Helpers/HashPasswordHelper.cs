using System.Security.Cryptography;
using System.Text;

namespace EPAMapp.Domain.Helpers
{
    public static class HashPasswordHelper
    {
        private static string Solt = "PowerOfTheSolt";
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashhedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + Solt));
                var hash = BitConverter.ToString(hashhedBytes).Replace("-", "").ToLower();
                
                return hash;
            }
        }
    }
}
