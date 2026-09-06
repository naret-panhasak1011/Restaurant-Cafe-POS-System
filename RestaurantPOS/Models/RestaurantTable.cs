using System;

namespace RestaurantPOS.Models
{
    /// <summary>Represents a physical restaurant table. Named RestaurantTable to avoid clashing with System.Data.DataTable.</summary>
    public class RestaurantTable
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; } = "Available"; // Available / Occupied / Reserved
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        // Populated when reading from vwActiveTableOrders — not persisted directly on this entity.
        public int? ActiveOrderID { get; set; }
        public decimal ActiveGrandTotal { get; set; }
        public string CashierName { get; set; }

        public bool IsAvailable => string.Equals(Status, "Available", StringComparison.OrdinalIgnoreCase);
        public bool IsOccupied => string.Equals(Status, "Occupied", StringComparison.OrdinalIgnoreCase);
        public bool IsReserved => string.Equals(Status, "Reserved", StringComparison.OrdinalIgnoreCase);

        public override string ToString() => TableName;
    }
}
