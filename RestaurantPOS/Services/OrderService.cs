using System;
using System.Collections.Generic;
using RestaurantPOS.DataAccess;
using RestaurantPOS.Models;

namespace RestaurantPOS.Services
{
    /// <summary>
    /// Implements the restaurant ordering workflow:
    /// Select Table -> Create/Open Order -> Add Items -> Save -> Back to Table (stays Occupied)
    /// -> Reopen -> Checkout -> Payment (handled by PaymentService).
    /// </summary>
    public class OrderService
    {
        private readonly OrderRepository _orderRepository = new OrderRepository();

        /// <summary>Opens the table for ordering: creates a new order, or loads the existing unpaid one.</summary>
        public Order OpenTableForOrder(int tableId, int userId)
        {
            _orderRepository.CreateOrGetOpenOrder(tableId, userId);
            return _orderRepository.GetOpenOrderByTable(tableId);
        }

        public Order GetOrderById(int orderId) => _orderRepository.GetById(orderId);

        /// <summary>Adds an item to the cart. Validates stock availability up front (the DB re-validates too).</summary>
        public void AddItem(int orderId, Product product, int quantity, string notes = null)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero.");
            if (!product.IsAvailable)
                throw new InvalidOperationException($"{product.ProductName} is currently unavailable.");
            if (product.StockQuantity < quantity)
                throw new InvalidOperationException($"Insufficient stock for {product.ProductName}. Available: {product.StockQuantity}.");

            _orderRepository.AddOrIncrementItem(orderId, product.ProductID, quantity, notes);
        }

        public void UpdateItemQuantity(int detailId, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero. Remove the item instead.");
            _orderRepository.SetItemQuantity(detailId, quantity);
        }

        public void RemoveItem(int detailId) => _orderRepository.RemoveItem(detailId);

        public void ApplyDiscount(int orderId, decimal discountAmount)
        {
            if (discountAmount < 0)
                throw new ArgumentException("Discount cannot be negative.");
            _orderRepository.ApplyDiscount(orderId, discountAmount);
        }

        /// <summary>Reloads the order with fresh totals — call after any cart mutation to refresh the UI.</summary>
        public Order Refresh(int orderId) => _orderRepository.GetById(orderId);

        public List<Order> SearchOrders(int? orderId, string tableName, string cashierName, DateTime? fromDate, DateTime? toDate, string orderStatus = null)
            => _orderRepository.SearchOrders(orderId, tableName, cashierName, fromDate, toDate, orderStatus);
    }
}
