using System;

namespace RestaurantPOS.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public string PaymentMethod { get; set; } // Cash / KHQR / Card
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount { get; set; }
        public string TransactionRef { get; set; }
        public DateTime PaidAt { get; set; }
        public string PaymentStatus { get; set; } = "Completed";
    }
}
