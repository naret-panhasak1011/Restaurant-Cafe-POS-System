using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class ProductRepository
    {
        public List<Product> Search(string searchTerm = null)
        {
            var table = DatabaseHelper.ExecuteDataTable("dbo.sp_ProductCRUD", CommandType.StoredProcedure,
                DatabaseHelper.Param("@Action", "SEARCH"),
                DatabaseHelper.Param("@ProductName", string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm));

            var list = new List<Product>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public List<Product> GetByCategory(int categoryId)
        {
            const string sql = @"
                SELECT p.*, c.CategoryName FROM dbo.tblProducts p
                INNER JOIN dbo.tblCategories c ON c.CategoryID = p.CategoryID
                WHERE p.CategoryID = @CategoryID AND p.IsAvailable = 1
                ORDER BY p.ProductName;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@CategoryID", categoryId));

            var list = new List<Product>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public List<Product> GetAllAvailable()
        {
            const string sql = @"
                SELECT p.*, c.CategoryName FROM dbo.tblProducts p
                INNER JOIN dbo.tblCategories c ON c.CategoryID = p.CategoryID
                WHERE p.IsAvailable = 1
                ORDER BY c.CategoryName, p.ProductName;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);

            var list = new List<Product>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public Product GetById(int productId)
        {
            const string sql = @"
                SELECT p.*, c.CategoryName FROM dbo.tblProducts p
                INNER JOIN dbo.tblCategories c ON c.CategoryID = p.CategoryID
                WHERE p.ProductID = @ProductID;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@ProductID", productId));
            return table.Rows.Count == 0 ? null : Map(table.Rows[0]);
        }

        public int Insert(Product p)
        {
            var result = DatabaseHelper.ExecuteScalar("dbo.sp_ProductCRUD", CommandType.StoredProcedure,
                DatabaseHelper.Param("@Action", "INSERT"),
                DatabaseHelper.Param("@CategoryID", p.CategoryID),
                DatabaseHelper.Param("@ProductName", p.ProductName),
                DatabaseHelper.Param("@UnitPrice", p.UnitPrice),
                DatabaseHelper.Param("@StockQuantity", p.StockQuantity),
                DatabaseHelper.Param("@IsAvailable", p.IsAvailable));
            return Convert.ToInt32(result);
        }

        public void Update(Product p)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_ProductCRUD", CommandType.StoredProcedure,
                DatabaseHelper.Param("@Action", "UPDATE"),
                DatabaseHelper.Param("@ProductID", p.ProductID),
                DatabaseHelper.Param("@CategoryID", p.CategoryID),
                DatabaseHelper.Param("@ProductName", p.ProductName),
                DatabaseHelper.Param("@UnitPrice", p.UnitPrice),
                DatabaseHelper.Param("@StockQuantity", p.StockQuantity),
                DatabaseHelper.Param("@IsAvailable", p.IsAvailable));
        }

        public void Delete(int productId)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_ProductCRUD", CommandType.StoredProcedure,
                DatabaseHelper.Param("@Action", "DELETE"),
                DatabaseHelper.Param("@ProductID", productId));
        }

        public void UpdateStock(int productId, int newQuantity)
        {
            const string sql = "UPDATE dbo.tblProducts SET StockQuantity = @Qty, UpdatedAt = SYSDATETIME() WHERE ProductID = @ProductID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@Qty", newQuantity),
                DatabaseHelper.Param("@ProductID", productId));
        }

        public bool NameExists(string name, int? excludeId = null)
        {
            const string sql = @"
                SELECT COUNT(1) FROM dbo.tblProducts
                WHERE ProductName = @Name AND (@ExcludeID IS NULL OR ProductID <> @ExcludeID);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@Name", name),
                DatabaseHelper.Param("@ExcludeID", excludeId));
            return Convert.ToInt32(result) > 0;
        }

        private static Product Map(DataRow row) => new Product
        {
            ProductID = Convert.ToInt32(row["ProductID"]),
            CategoryID = Convert.ToInt32(row["CategoryID"]),
            CategoryName = row.Table.Columns.Contains("CategoryName") ? row["CategoryName"].ToString() : null,
            ProductName = row["ProductName"].ToString(),
            UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
            StockQuantity = Convert.ToInt32(row["StockQuantity"]),
            IsAvailable = Convert.ToBoolean(row["IsAvailable"]),
            CreatedAt = row.Table.Columns.Contains("CreatedAt") && row["CreatedAt"] != DBNull.Value
                ? Convert.ToDateTime(row["CreatedAt"]) : DateTime.MinValue,
            UpdatedAt = row.Table.Columns.Contains("UpdatedAt") && row["UpdatedAt"] != DBNull.Value
                ? Convert.ToDateTime(row["UpdatedAt"]) : (DateTime?)null
        };
    }
}
