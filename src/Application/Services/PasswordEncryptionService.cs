using Application.Interfaces;
using System.Security.Cryptography;

namespace Application.Services
{
    public class PasswordEncryptionService : IPasswordEncryptionService
    {
        public string HashPassword(string password)
        {
            string hashedPasswordString = string.Empty;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);

                byte[] hashedPassword = sha256.ComputeHash(passwordBytes);

                hashedPasswordString = System.BitConverter.ToString(hashedPassword).Replace("-", "");
            }
            return hashedPasswordString;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            HashPassword(password);

            return password == hashedPassword;
        }
    }
}
