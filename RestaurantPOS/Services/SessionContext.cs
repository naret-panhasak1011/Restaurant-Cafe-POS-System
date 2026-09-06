using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    /// <summary>Simple process-wide session holder for the currently logged-in user.</summary>
    public static class SessionContext
    {
        public static User CurrentUser { get; set; }

        public static bool IsAdmin => CurrentUser != null && CurrentUser.IsAdmin;

        public static void Clear() => CurrentUser = null;
    }
}
