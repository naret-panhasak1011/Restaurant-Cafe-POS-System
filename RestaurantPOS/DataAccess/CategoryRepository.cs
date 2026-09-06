using System;
using System.Collections.Generic;
using System.Data;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class CategoryRepository
    {
        public List<Category> GetAll(string searchTerm = null)
        {
            const string sql = @"
                SELECT * FROM dbo.tblCategories
                WHERE IsActive = 1 AND (@Search IS NULL OR CategoryName LIKE '%' + @Search + '%')
                ORDER BY CategoryName;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@Search", string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm));

            var list = new List<Category>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public int Insert(Category c)
        {
            const string sql = @"
                INSERT INTO dbo.tblCategories (CategoryName) VALUES (@CategoryName);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@CategoryName", c.CategoryName));
            return Convert.ToInt32(result);
        }

        public void Update(Category c)
        {
            const string sql = "UPDATE dbo.tblCategories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@CategoryName", c.CategoryName),
                DatabaseHelper.Param("@CategoryID", c.CategoryID));
        }

        public void Delete(int categoryId)
        {
            const string sql = "UPDATE dbo.tblCategories SET IsActive = 0 WHERE CategoryID = @CategoryID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text, DatabaseHelper.Param("@CategoryID", categoryId));
        }

        public bool NameExists(string name, int? excludeId = null)
        {
            const string sql = @"
                SELECT COUNT(1) FROM dbo.tblCategories
                WHERE CategoryName = @Name AND (@ExcludeID IS NULL OR CategoryID <> @ExcludeID);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@Name", name),
                DatabaseHelper.Param("@ExcludeID", excludeId));
            return Convert.ToInt32(result) > 0;
        }

        private static Category Map(DataRow row) => new Category
        {
            CategoryID = Convert.ToInt32(row["CategoryID"]),
            CategoryName = row["CategoryName"].ToString(),
            IsActive = Convert.ToBoolean(row["IsActive"]),
            CreatedAt = Convert.ToDateTime(row["CreatedAt"])
        };
    }
}
