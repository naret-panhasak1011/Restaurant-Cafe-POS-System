using System;

namespace RestaurantPOS.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public override string ToString() => CategoryName;
    }
}
