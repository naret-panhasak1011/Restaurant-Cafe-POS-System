namespace RestaurantPOS.Models
{
    /// <summary>
    /// Abstract base for menu items. Demonstrates OOP Abstraction/Inheritance on top of
    /// the flat Product entity — used by the POS billing screen when building the cart.
    /// </summary>
    public abstract class MenuItem
    {
        public int ProductID { get; protected set; }
        public string Name { get; protected set; }
        public decimal UnitPrice { get; protected set; }

        protected MenuItem(int productId, string name, decimal unitPrice)
        {
            ProductID = productId;
            Name = name;
            UnitPrice = unitPrice;
        }

        /// <summary>Polymorphic hook: each menu item type may describe itself differently (e.g. receipt tag).</summary>
        public abstract string GetDisplayTag();

        public static MenuItem FromProduct(Product product)
        {
            // Simple category-based classification for demonstration of inheritance/polymorphism.
            var beverageCategories = new[] { "Coffee", "Tea", "Juice", "Soft Drink" };
            foreach (var cat in beverageCategories)
            {
                if (string.Equals(product.CategoryName, cat, System.StringComparison.OrdinalIgnoreCase))
                    return new BeverageItem(product.ProductID, product.ProductName, product.UnitPrice);
            }
            return new FoodItem(product.ProductID, product.ProductName, product.UnitPrice);
        }
    }
}
