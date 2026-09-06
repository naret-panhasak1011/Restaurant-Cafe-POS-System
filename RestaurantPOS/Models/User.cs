using System;

namespace RestaurantPOS.Models
{
    /// <summary>Represents an application user (Admin or Cashier). Encapsulated model (OOP: Encapsulation).</summary>
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }          // "Admin" or "Cashier"
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsAdmin => string.Equals(Role, "Admin", StringComparison.OrdinalIgnoreCase);
        public bool IsCashier => string.Equals(Role, "Cashier", StringComparison.OrdinalIgnoreCase);

        public override string ToString() => $"{FullName} ({Role})";
    }
}
