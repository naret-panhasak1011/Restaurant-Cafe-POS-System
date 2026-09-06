using RestaurantPOS.Models;

namespace RestaurantPOS.Interfaces
{
    /// <summary>
    /// Abstraction over how a payment is processed (OOP: Abstraction/Polymorphism).
    /// CashPayment, QRPayment, and CardPayment each implement this differently.
    /// </summary>
    public interface IPaymentProcessor
    {
        string MethodName { get; }

        /// <summary>Validates and computes the result of the payment attempt (e.g. change due).</summary>
        PaymentResult Process(decimal grandTotal, decimal amountTendered, string transactionRef = null);
    }

    /// <summary>Result returned by an IPaymentProcessor implementation.</summary>
    public class PaymentResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal ChangeAmount { get; set; }
        public string TransactionRef { get; set; }
    }
}
