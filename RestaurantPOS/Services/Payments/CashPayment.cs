using RestaurantPOS.Interfaces;

namespace RestaurantPOS.Services.Payments
{
    /// <summary>Cash payment: validates the amount tendered covers the total and computes change.</summary>
    public class CashPayment : IPaymentProcessor
    {
        public string MethodName => "Cash";

        public PaymentResult Process(decimal grandTotal, decimal amountTendered, string transactionRef = null)
        {
            if (amountTendered < grandTotal)
            {
                return new PaymentResult
                {
                    Success = false,
                    Message = "Cash received is less than the grand total.",
                    AmountPaid = amountTendered,
                    ChangeAmount = 0
                };
            }

            return new PaymentResult
            {
                Success = true,
                Message = "Cash payment accepted.",
                AmountPaid = amountTendered,
                ChangeAmount = amountTendered - grandTotal,
                TransactionRef = null
            };
        }
    }
}
