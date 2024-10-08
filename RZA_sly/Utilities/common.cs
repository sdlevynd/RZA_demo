using System.Text;
using System.Security.Cryptography;

namespace RZA_sly.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Convert the password to a byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the byte array to a hexadecimal string
                var sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));  // "x2" for hexadecimal formatting
                }

                return sb.ToString();  // Return the hashed password as a string
            }
        }
    }
    public class UserSession
    {
        public int UserId { get; set; }
    }

    public class SessionStorage
    {
        private string? savedString;

        public string UserId
        {
            get => savedString ?? string.Empty;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }

        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
