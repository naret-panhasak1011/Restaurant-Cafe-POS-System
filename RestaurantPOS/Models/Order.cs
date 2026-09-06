using System;
using System.Collections.Generic;

namespace RestaurantPOS.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int UserID { get; set; }
        public string CashierName { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; } = 10.00m;
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }

        public string OrderStatus { get; set; } = "Open";     // Open / Completed / Cancelled
        public string PaymentStatus { get; set; } = "Unpaid"; // Unpaid / Paid / Refunded

        public string Notes { get; set; }
        public DateTime? CompletedAt { get; set; }

        public List<OrderDetail> Items { get; set; } = new List<OrderDetail>();

        public bool IsOpen => string.Equals(OrderStatus, "Open", StringComparison.OrdinalIgnoreCase);
        public bool IsPaid => string.Equals(PaymentStatus, "Paid", StringComparison.OrdinalIgnoreCase);
    }
}
