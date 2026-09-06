using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class OrderRepository
    {
        /// <summary>
        /// Opens a new order for the table, or returns the already-open one
        /// (sp_CreateOrder is idempotent per table) — this is what makes
        /// "reopen the same table" work instead of creating duplicate orders.
        /// </summary>
        public int CreateOrGetOpenOrder(int tableId, int userId)
        {
            var outputParam = DatabaseHelper.OutputParam("@OrderID", SqlDbType.Int);
            DatabaseHelper.ExecuteWithOutput("dbo.sp_CreateOrder", "@OrderID",
                DatabaseHelper.Param("@TableID", tableId),
                DatabaseHelper.Param("@UserID", userId),
                outputParam);
            return Convert.ToInt32(outputParam.Value);
        }

        public Order GetOpenOrderByTable(int tableId)
        {
            const string sql = @"
                SELECT TOP 1 o.*, t.TableName, u.FullName AS CashierName
                FROM dbo.tblOrders o
                INNER JOIN dbo.tblTables t ON t.TableID = o.TableID
                INNER JOIN dbo.tblUsers u ON u.UserID = o.UserID
                WHERE o.TableID = @TableID AND o.OrderStatus = 'Open' AND o.PaymentStatus = 'Unpaid'
                ORDER BY o.OrderID DESC;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@TableID", tableId));
            if (table.Rows.Count == 0) return null;

            var order = MapOrder(table.Rows[0]);
            order.Items = GetOrderDetails(order.OrderID);
            return order;
        }

        public Order GetById(int orderId)
        {
            const string sql = @"
                SELECT o.*, t.TableName, u.FullName AS CashierName
                FROM dbo.tblOrders o
                INNER JOIN dbo.tblTables t ON t.TableID = o.TableID
                INNER JOIN dbo.tblUsers u ON u.UserID = o.UserID
                WHERE o.OrderID = @OrderID;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@OrderID", orderId));
            if (table.Rows.Count == 0) return null;

            var order = MapOrder(table.Rows[0]);
            order.Items = GetOrderDetails(order.OrderID);
            return order;
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            const string sql = @"
                SELECT od.*, p.ProductName
                FROM dbo.tblOrderDetails od
                INNER JOIN dbo.tblProducts p ON p.ProductID = od.ProductID
                WHERE od.OrderID = @OrderID
                ORDER BY od.DetailID;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@OrderID", orderId));

            var list = new List<OrderDetail>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new OrderDetail
                {
                    DetailID = Convert.ToInt32(row["DetailID"]),
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    ProductID = Convert.ToInt32(row["ProductID"]),
                    ProductName = row["ProductName"].ToString(),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Notes = row["Notes"] as string
                });
            }
            return list;
        }

        public void AddOrIncrementItem(int orderId, int productId, int quantity, string notes = null)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_SaveOrderDetail", CommandType.StoredProcedure,
                DatabaseHelper.Param("@OrderID", orderId),
                DatabaseHelper.Param("@ProductID", productId),
                DatabaseHelper.Param("@Quantity", quantity),
                DatabaseHelper.Param("@Notes", notes));
        }

        public void SetItemQuantity(int detailId, int quantity)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_UpdateOrderDetailQuantity", CommandType.StoredProcedure,
                DatabaseHelper.Param("@DetailID", detailId),
                DatabaseHelper.Param("@Quantity", quantity));
        }

        public void RemoveItem(int detailId)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_RemoveOrderDetail", CommandType.StoredProcedure,
                DatabaseHelper.Param("@DetailID", detailId));
        }

        public void ApplyDiscount(int orderId, decimal discountAmount)
        {
            DatabaseHelper.ExecuteNonQuery("dbo.sp_ApplyOrderDiscount", CommandType.StoredProcedure,
                DatabaseHelper.Param("@OrderID", orderId),
                DatabaseHelper.Param("@DiscountAmount", discountAmount));
        }

        public List<Order> SearchOrders(int? orderId, string tableName, string cashierName, DateTime? fromDate, DateTime? toDate, string orderStatus = null)
        {
            const string sql = @"
                SELECT o.*, t.TableName, u.FullName AS CashierName
                FROM dbo.tblOrders o
                INNER JOIN dbo.tblTables t ON t.TableID = o.TableID
                INNER JOIN dbo.tblUsers u ON u.UserID = o.UserID
                WHERE (@OrderID IS NULL OR o.OrderID = @OrderID)
                  AND (@TableName IS NULL OR t.TableName LIKE '%' + @TableName + '%')
                  AND (@CashierName IS NULL OR u.FullName LIKE '%' + @CashierName + '%')
                  AND (@FromDate IS NULL OR o.OrderDate >= @FromDate)
                  AND (@ToDate IS NULL OR o.OrderDate < DATEADD(DAY, 1, @ToDate))
                  AND (@OrderStatus IS NULL OR o.OrderStatus = @OrderStatus)
                ORDER BY o.OrderDate DESC;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@OrderID", orderId),
                DatabaseHelper.Param("@TableName", string.IsNullOrWhiteSpace(tableName) ? null : tableName),
                DatabaseHelper.Param("@CashierName", string.IsNullOrWhiteSpace(cashierName) ? null : cashierName),
                DatabaseHelper.Param("@FromDate", fromDate),
                DatabaseHelper.Param("@ToDate", toDate),
                DatabaseHelper.Param("@OrderStatus", string.IsNullOrWhiteSpace(orderStatus) ? null : orderStatus));

            var list = new List<Order>();
            foreach (DataRow row in table.Rows) list.Add(MapOrder(row));
            return list;
        }

        private static Order MapOrder(DataRow row) => new Order
        {
            OrderID = Convert.ToInt32(row["OrderID"]),
            TableID = Convert.ToInt32(row["TableID"]),
            TableName = row["TableName"].ToString(),
            UserID = Convert.ToInt32(row["UserID"]),
            CashierName = row["CashierName"].ToString(),
            OrderDate = Convert.ToDateTime(row["OrderDate"]),
            SubTotal = Convert.ToDecimal(row["SubTotal"]),
            TaxRate = Convert.ToDecimal(row["TaxRate"]),
            TaxAmount = Convert.ToDecimal(row["TaxAmount"]),
            DiscountAmount = Convert.ToDecimal(row["DiscountAmount"]),
            GrandTotal = Convert.ToDecimal(row["GrandTotal"]),
            OrderStatus = row["OrderStatus"].ToString(),
            PaymentStatus = row["PaymentStatus"].ToString(),
            Notes = row["Notes"] as string,
            CompletedAt = row["CompletedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["CompletedAt"])
        };
    }
}
