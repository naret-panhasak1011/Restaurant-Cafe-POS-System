using System;

namespace RestaurantPOS.Models
{
    /// <summary>Plain product record mapped directly to tblProducts (used for grids / CRUD).</summary>
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public override string ToString() => ProductName;
    }
}
