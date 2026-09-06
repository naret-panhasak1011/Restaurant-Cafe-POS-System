using System;
using System.Collections.Generic;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository = new UserRepository();

        public List<User> GetAll(string search = null) => _userRepository.GetAll(search);

        public void AddUser(string username, string password, string fullName, string role)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Username, password, and full name are all required.");
            if (role != "Admin" && role != "Cashier")
                throw new ArgumentException("Role must be Admin or Cashier.");
            if (_userRepository.UsernameExists(username.Trim()))
                throw new InvalidOperationException("This username is already taken.");

            _userRepository.Insert(new User
            {
                Username = username.Trim(),
                PasswordHash = AuthService.HashPassword(password),
                FullName = fullName.Trim(),
                Role = role,
                IsActive = true
            });
        }

        public void UpdateUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.FullName))
                throw new ArgumentException("Full name is required.");
            if (user.Role != "Admin" && user.Role != "Cashier")
                throw new ArgumentException("Role must be Admin or Cashier.");

            _userRepository.Update(user);
        }

        public void ResetPassword(int userId, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 4)
                throw new ArgumentException("Password must be at least 4 characters.");

            _userRepository.UpdatePassword(userId, AuthService.HashPassword(newPassword));
        }

        public void SetActive(int userId, bool isActive) => _userRepository.SetActive(userId, isActive);

        public void DeleteUser(int userId) => _userRepository.Delete(userId);
    }
}
