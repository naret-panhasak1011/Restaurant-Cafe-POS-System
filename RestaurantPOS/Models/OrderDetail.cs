namespace RestaurantPOS.Models
{
    public class OrderDetail
    {
        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
