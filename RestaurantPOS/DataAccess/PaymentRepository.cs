using System;
using System.Data;
using RestaurantPOS.Models;

namespace RestaurantPOS.DataAccess
{
    public class PaymentRepository
    {
        /// <summary>
        /// Completes the order: marks it Paid/Completed, records the payment,
        /// deducts stock, and frees the table — all inside sp_CompleteOrder's transaction.
        /// Returns the persisted Payment row.
        /// </summary>
        public Payment CompleteOrder(int orderId, string paymentMethod, decimal amountPaid, string transactionRef = null)
        {
            var table = DatabaseHelper.ExecuteDataTable("dbo.sp_CompleteOrder", CommandType.StoredProcedure,
                DatabaseHelper.Param("@OrderID", orderId),
                DatabaseHelper.Param("@PaymentMethod", paymentMethod),
                DatabaseHelper.Param("@AmountPaid", amountPaid),
                DatabaseHelper.Param("@TransactionRef", transactionRef));

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Payment could not be confirmed by the database.");

            var row = table.Rows[0];
            return new Payment
            {
                OrderID = Convert.ToInt32(row["OrderID"]),
                PaymentMethod = row["PaymentMethod"].ToString(),
                AmountPaid = Convert.ToDecimal(row["AmountPaid"]),
                ChangeAmount = Convert.ToDecimal(row["ChangeAmount"]),
                PaidAt = Convert.ToDateTime(row["PaidAt"]),
                PaymentStatus = "Completed"
            };
        }

        public Payment GetByOrderId(int orderId)
        {
            const string sql = "SELECT * FROM dbo.tblPayments WHERE OrderID = @OrderID;";
            var table = DatabaseHelper.ExecuteDataTable(sql, CommandType.Text,
                DatabaseHelper.Param("@OrderID", orderId));
            if (table.Rows.Count == 0) return null;

            var row = table.Rows[0];
            return new Payment
            {
                PaymentID = Convert.ToInt32(row["PaymentID"]),
                OrderID = Convert.ToInt32(row["OrderID"]),
                PaymentMethod = row["PaymentMethod"].ToString(),
                AmountPaid = Convert.ToDecimal(row["AmountPaid"]),
                ChangeAmount = Convert.ToDecimal(row["ChangeAmount"]),
                TransactionRef = row["TransactionRef"] as string,
                PaidAt = Convert.ToDateTime(row["PaidAt"]),
                PaymentStatus = row["PaymentStatus"].ToString()
            };
        }
    }
}
