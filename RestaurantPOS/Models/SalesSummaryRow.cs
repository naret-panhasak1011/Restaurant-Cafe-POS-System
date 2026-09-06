using System;

namespace RestaurantPOS.Models
{
    /// <summary>Maps to vwSalesSummary — used by frmSalesReport.</summary>
    public class SalesSummaryRow
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string TableName { get; set; }
        public string CashierName { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount { get; set; }
        public string TransactionRef { get; set; }
        public DateTime? PaidAt { get; set; }
        public int ItemCount { get; set; }
    }
}
