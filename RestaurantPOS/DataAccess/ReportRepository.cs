using System;
using System.Collections.Generic;
using System.Data;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class ReportRepository
    {
        public List<SalesSummaryRow> GetSales(DateTime? fromDate, DateTime? toDate, string paymentMethod = null, string orderStatus = null)
        {
            const string sql = @"
                SELECT
                    o.OrderID, o.OrderDate, t.TableName, u.FullName AS CashierName,
                    o.SubTotal, o.TaxRate, o.TaxAmount, o.DiscountAmount, o.GrandTotal,
                    o.OrderStatus, o.PaymentStatus,
                    p.PaymentMethod, p.AmountPaid, p.ChangeAmount, p.TransactionRef, p.PaidAt,
                    (SELECT ISNULL(SUM(od.Quantity), 0)
                     FROM dbo.tblOrderDetails od
                     WHERE od.OrderID = o.OrderID) AS ItemCount
                FROM dbo.tblOrders o
                INNER JOIN dbo.tblTables t ON t.TableID = o.TableID
                INNER JOIN dbo.tblUsers u ON u.UserID = o.UserID
                LEFT JOIN dbo.tblPayments p ON p.OrderID = o.OrderID
                WHERE (@FromDate IS NULL OR o.OrderDate >= @FromDate)
                  AND (@ToDate IS NULL OR o.OrderDate < DATEADD(DAY, 1, @ToDate))
                  AND (@PaymentMethod IS NULL OR p.PaymentMethod = @PaymentMethod)
                  AND (@OrderStatus IS NULL OR o.OrderStatus = @OrderStatus)
                ORDER BY o.OrderDate DESC;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@FromDate", fromDate),
                DatabaseHelper.Param("@ToDate", toDate),
                DatabaseHelper.Param("@PaymentMethod", string.IsNullOrWhiteSpace(paymentMethod) ? null : paymentMethod),
                DatabaseHelper.Param("@OrderStatus", string.IsNullOrWhiteSpace(orderStatus) ? null : orderStatus));

            var list = new List<SalesSummaryRow>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new SalesSummaryRow
                {
                    OrderID = Convert.ToInt32(row["OrderID"]),
                    OrderDate = Convert.ToDateTime(row["OrderDate"]),
                    TableName = row["TableName"].ToString(),
                    CashierName = row["CashierName"].ToString(),
                    SubTotal = Convert.ToDecimal(row["SubTotal"]),
                    TaxRate = Convert.ToDecimal(row["TaxRate"]),
                    TaxAmount = Convert.ToDecimal(row["TaxAmount"]),
                    DiscountAmount = Convert.ToDecimal(row["DiscountAmount"]),
                    GrandTotal = Convert.ToDecimal(row["GrandTotal"]),
                    OrderStatus = row["OrderStatus"].ToString(),
                    PaymentStatus = row["PaymentStatus"].ToString(),
                    PaymentMethod = row["PaymentMethod"] as string,
                    AmountPaid = row["AmountPaid"] == DBNull.Value ? 0 : Convert.ToDecimal(row["AmountPaid"]),
                    ChangeAmount = row["ChangeAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["ChangeAmount"]),
                    TransactionRef = row["TransactionRef"] as string,
                    PaidAt = row["PaidAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["PaidAt"]),
                    ItemCount = Convert.ToInt32(row["ItemCount"])
                });
            }
            return list;
        }

        /// <summary>Dashboard summary for "today".</summary>
        public (int OrderCount, decimal Revenue, decimal Tax, int ItemsSold) GetTodaySummary()
        {
            const string sql = @"
                SELECT
                    COUNT(*) AS OrderCount,
                    ISNULL(SUM(o.GrandTotal), 0) AS Revenue,
                    ISNULL(SUM(o.TaxAmount), 0) AS Tax,
                    ISNULL((SELECT SUM(od.Quantity)
                            FROM dbo.tblOrderDetails od
                            INNER JOIN dbo.tblOrders o2 ON o2.OrderID = od.OrderID
                            WHERE o2.OrderStatus = 'Completed' AND o2.PaymentStatus = 'Paid'
                              AND CAST(o2.CompletedAt AS DATE) = CAST(SYSDATETIME() AS DATE)), 0) AS ItemsSold
                FROM dbo.tblOrders o
                WHERE o.OrderStatus = 'Completed' AND o.PaymentStatus = 'Paid'
                  AND CAST(o.CompletedAt AS DATE) = CAST(SYSDATETIME() AS DATE);";

            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text);
            if (table.Rows.Count == 0) return (0, 0, 0, 0);

            var row = table.Rows[0];
            return (
                Convert.ToInt32(row["OrderCount"]),
                Convert.ToDecimal(row["Revenue"]),
                Convert.ToDecimal(row["Tax"]),
                Convert.ToInt32(row["ItemsSold"])
            );
        }

        public DataTable GetBestSellers(DateTime? fromDate, DateTime? toDate, int top = 10)
        {
            const string sql = @"
                SELECT TOP (@Top)
                    p.ProductName,
                    SUM(od.Quantity) AS TotalSold,
                    SUM(od.TotalPrice) AS Revenue
                FROM dbo.tblOrderDetails od
                INNER JOIN dbo.tblProducts p ON p.ProductID = od.ProductID
                INNER JOIN dbo.tblOrders o ON o.OrderID = od.OrderID
                WHERE o.OrderStatus = 'Completed' AND o.PaymentStatus = 'Paid'
                  AND (@FromDate IS NULL OR o.OrderDate >= @FromDate)
                  AND (@ToDate IS NULL OR o.OrderDate < DATEADD(DAY, 1, @ToDate))
                GROUP BY p.ProductName
                ORDER BY TotalSold DESC;";
            return DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@Top", top),
                DatabaseHelper.Param("@FromDate", fromDate),
                DatabaseHelper.Param("@ToDate", toDate));
        }
    }
}
