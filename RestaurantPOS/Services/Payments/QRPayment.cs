using RestaurantPOS.Interfaces;

namespace RestaurantPOS.Services.Payments
{
    /// <summary>KHQR payment: exact amount, no change; requires a confirmed transaction reference.</summary>
    public class QRPayment : IPaymentProcessor
    {
        public string MethodName => "KHQR";

        public PaymentResult Process(decimal grandTotal, decimal amountTendered, string transactionRef = null)
        {
            if (string.IsNullOrWhiteSpace(transactionRef))
            {
                return new PaymentResult
                {
                    Success = false,
                    Message = "KHQR payment must be confirmed before completing the order.",
                    AmountPaid = 0,
                    ChangeAmount = 0
                };
            }

            return new PaymentResult
            {
                Success = true,
                Message = "KHQR payment confirmed.",
                AmountPaid = grandTotal,
                ChangeAmount = 0,
                TransactionRef = transactionRef
            };
        }
    }
}
