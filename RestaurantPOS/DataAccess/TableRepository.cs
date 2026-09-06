using System;
using System.Collections.Generic;
using System.Data;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class TableRepository
    {
        /// <summary>Loads every table plus its currently active order (if any), for the table overview screen.</summary>
        public List<RestaurantTable> GetAllWithActiveOrders()
        {
            const string sql = @"
                SELECT TableID, TableName, Capacity, TableStatus, IsActive = CAST(1 AS BIT),
                       OrderID, GrandTotal, CashierName
                FROM dbo.vwActiveTableOrders
                ORDER BY TableName;";

            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            var list = new List<RestaurantTable>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new RestaurantTable
                {
                    TableID = Convert.ToInt32(row["TableID"]),
                    TableName = row["TableName"].ToString(),
                    Capacity = Convert.ToInt32(row["Capacity"]),
                    Status = row["TableStatus"].ToString(),
                    IsActive = true,
                    ActiveOrderID = row["OrderID"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["OrderID"]),
                    ActiveGrandTotal = row["GrandTotal"] == DBNull.Value ? 0 : Convert.ToDecimal(row["GrandTotal"]),
                    CashierName = row["CashierName"] as string
                });
            }
            return list;
        }

        public List<RestaurantTable> GetAll(string searchTerm = null)
        {
            const string sql = @"
                SELECT * FROM dbo.tblTables
                WHERE IsActive = 1 AND (@Search IS NULL OR TableName LIKE '%' + @Search + '%')
                ORDER BY TableName;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@Search", string.IsNullOrWhiteSpace(searchTerm) ? null : searchTerm));

            var list = new List<RestaurantTable>();
            foreach (DataRow row in table.Rows) list.Add(Map(row));
            return list;
        }

        public int Insert(RestaurantTable t)
        {
            const string sql = @"
                INSERT INTO dbo.tblTables (TableName, Capacity, Status)
                VALUES (@TableName, @Capacity, @Status);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";
            var result = DatabaseHelper.ExecuteScalar(sql, CommandType.Text,
                DatabaseHelper.Param("@TableName", t.TableName),
                DatabaseHelper.Param("@Capacity", t.Capacity),
                DatabaseHelper.Param("@Status", t.Status));
            return Convert.ToInt32(result);
        }

        public void Update(RestaurantTable t)
        {
            const string sql = @"
                UPDATE dbo.tblTables
                SET TableName = @TableName, Capacity = @Capacity, Status = @Status
                WHERE TableID = @TableID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@TableName", t.TableName),
                DatabaseHelper.Param("@Capacity", t.Capacity),
                DatabaseHelper.Param("@Status", t.Status),
                DatabaseHelper.Param("@TableID", t.TableID));
        }

        public void Delete(int tableId)
        {
            const string sql = "UPDATE dbo.tblTables SET IsActive = 0 WHERE TableID = @TableID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text, DatabaseHelper.Param("@TableID", tableId));
        }

        public void UpdateStatus(int tableId, string status)
        {
            const string sql = "UPDATE dbo.tblTables SET Status = @Status WHERE TableID = @TableID;";
            DatabaseHelper.ExecuteNonQuery(sql, CommandType.Text,
                DatabaseHelper.Param("@Status", status),
                DatabaseHelper.Param("@TableID", tableId));
        }

        private static RestaurantTable Map(DataRow row) => new RestaurantTable
        {
            TableID = Convert.ToInt32(row["TableID"]),
            TableName = row["TableName"].ToString(),
            Capacity = Convert.ToInt32(row["Capacity"]),
            Status = row["Status"].ToString(),
            IsActive = Convert.ToBoolean(row["IsActive"]),
            CreatedAt = Convert.ToDateTime(row["CreatedAt"])
        };
    }
}
