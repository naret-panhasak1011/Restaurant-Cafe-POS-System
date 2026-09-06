using System;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Interfaces;
using RestaurantPOS.Models;
using RestaurantPOS.Services.Payments;

namespace RestaurantPOS.Services
{
    /// <summary>
    /// Selects the correct IPaymentProcessor implementation (polymorphism) and,
    /// once validated locally, calls sp_CompleteOrder to atomically finalize the
    /// order, record the payment, deduct stock, and free the table.
    /// </summary>
    public class PaymentService
    {
        private readonly PaymentRepository _paymentRepository = new PaymentRepository();

        private static IPaymentProcessor ResolveProcessor(string method) => method switch
        {
            "Cash" => new CashPayment(),
            "KHQR" => new QRPayment(),
            "Card" => new CardPayment(),
            _ => throw new ArgumentException($"Unsupported payment method: {method}")
        };

        /// <summary>
        /// Validates the payment client-side via the matching processor, then persists
        /// it through the database (which re-validates order status/amount server-side).
        /// </summary>
        public Payment ProcessPayment(Order order, string method, decimal amountTendered, string transactionRef, out string errorMessage)
        {
            errorMessage = null;

            if (order == null || !order.IsOpen || order.IsPaid)
            {
                errorMessage = "This order is not open for payment.";
                return null;
            }

            if (order.Items.Count == 0)
            {
                errorMessage = "Cannot process payment for an empty order.";
                return null;
            }

            var processor = ResolveProcessor(method);
            var result = processor.Process(order.GrandTotal, amountTendered, transactionRef);

            if (!result.Success)
            {
                errorMessage = result.Message;
                return null;
            }

            try
            {
                return _paymentRepository.CompleteOrder(order.OrderID, processor.MethodName, result.AmountPaid, result.TransactionRef);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return null;
            }
        }

        public Payment GetPaymentForOrder(int orderId) => _paymentRepository.GetByOrderId(orderId);
    }
}
