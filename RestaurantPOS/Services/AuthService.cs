using System;
using System.Security.Cryptography;
using System.Text;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    /// <summary>Handles login validation and password hashing (SHA-256, salted at the app level is out of scope for this classroom project).</summary>
    public class AuthService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public User CurrentUser { get; private set; }

        public static string HashPassword(string plainPassword)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
            var sb = new StringBuilder();
            foreach (var b in bytes) sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        /// <summary>Validates credentials against SQL Server. Returns the logged-in user, or null with an error message.</summary>
        public bool TryLogin(string username, string password, out User user, out string errorMessage)
        {
            user = null;
            errorMessage = null;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Please enter both username and password.";
                return false;
            }

            var found = _userRepository.FindByUsername(username.Trim());
            if (found == null)
            {
                errorMessage = "Invalid username or password.";
                return false;
            }

            if (!found.IsActive)
            {
                errorMessage = "This account has been deactivated. Please contact an administrator.";
                return false;
            }

            var hashed = HashPassword(password);
            if (!string.Equals(found.PasswordHash, hashed, StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = "Invalid username or password.";
                return false;
            }

            CurrentUser = found;
            user = found;
            return true;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
