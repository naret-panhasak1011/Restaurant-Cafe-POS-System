using RestaurantPOS.Interfaces;

namespace RestaurantPOS.Services.Payments
{
    /// <summary>Card payment: exact amount, no change; requires a confirmed transaction reference (e.g. terminal approval code).</summary>
    public class CardPayment : IPaymentProcessor
    {
        public string MethodName => "Card";

        public PaymentResult Process(decimal grandTotal, decimal amountTendered, string transactionRef = null)
        {
            if (string.IsNullOrWhiteSpace(transactionRef))
            {
                return new PaymentResult
                {
                    Success = false,
                    Message = "Card payment must be confirmed before completing the order.",
                    AmountPaid = 0,
                    ChangeAmount = 0
                };
            }

            return new PaymentResult
            {
                Success = true,
                Message = "Card payment approved.",
                AmountPaid = grandTotal,
                ChangeAmount = 0,
                TransactionRef = transactionRef
            };
        }
    }
}
