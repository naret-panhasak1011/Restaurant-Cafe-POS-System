using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class UserRepository
    {
        public User FindByUsername(string username)
        {
            const string sql = "SELECT * FROM dbo.tblUsers WHERE Username = @Username;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@Username", username));

            if (table.Rows.Count == 0) return null;
            return Map(table.Rows[0]);
        }

        public User GetById(int userId)
        {
            const string sql = "SELECT * FROM dbo.tblUsers WHERE UserID = @UserID;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@UserID", userId));
            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        public List<User> GetAll(string searchTerm = null)
        {
            const string sql = @"
                SELECT * FROM dbo.tblUsers
                WHERE (@Search IS NULL OR Username LIKE '%' + @Search + '%' OR FullName LIKE '%' + @Search + '%')
                ORDER BY FullName;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@Search", string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm));

            var list = new List<User>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public int Insert(User user)
        {
            const string sql = @"
                INSERT INTO dbo.tblUsers (Username, PasswordHash, FullName, Role, IsActive)
                VALUES (@Username, @PasswordHash, @FullName, @Role, @IsActive);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@Username", user.Username),
                DatabaseHelper.Param("@PasswordHash", user.PasswordHash),
                DatabaseHelper.Param("@FullName", user.FullName),
                DatabaseHelper.Param("@Role", user.Role),
                DatabaseHelper.Param("@IsActive", user.IsActive));
            return Convert.ToInt32(result);
        }

        public void Update(User user)
        {
            const string sql = @"
                UPDATE dbo.tblUsers
                SET FullName = @FullName, Role = @Role, IsActive = @IsActive
                WHERE UserID = @UserID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@FullName", user.FullName),
                DatabaseHelper.Param("@Role", user.Role),
                DatabaseHelper.Param("@IsActive", user.IsActive),
                DatabaseHelper.Param("@UserID", user.UserID));
        }

        public void UpdatePassword(int userId, string newPasswordHash)
        {
            const string sql = "UPDATE dbo.tblUsers SET PasswordHash = @Hash WHERE UserID = @UserID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@Hash", newPasswordHash),
                DatabaseHelper.Param("@UserID", userId));
        }

        public void SetActive(int userId, bool isActive)
        {
            const string sql = "UPDATE dbo.tblUsers SET IsActive = @IsActive WHERE UserID = @UserID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@IsActive", isActive),
                DatabaseHelper.Param("@UserID", userId));
        }

        public void Delete(int userId)
        {
            // Soft delete to preserve FK history on tblOrders.
            SetActive(userId, false);
        }

        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            const string sql = @"
                SELECT COUNT(1) FROM dbo.tblUsers
                WHERE Username = @Username AND (@ExcludeID IS NULL OR UserID <> @ExcludeID);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@Username", username),
                DatabaseHelper.Param("@ExcludeID", excludeUserId));
            return Convert.ToInt32(result) > 0;
        }

        private static User Map(DataRow row) => new User
        {
            UserID = Convert.ToInt32(row["UserID"]),
            Username = row["Username"].ToString(),
            PasswordHash = row["PasswordHash"].ToString(),
            FullName = row["FullName"].ToString(),
            Role = row["Role"].ToString(),
            IsActive = Convert.ToBoolean(row["IsActive"]),
            CreatedAt = Convert.ToDateTime(row["CreatedAt"])
        };
    }
}
