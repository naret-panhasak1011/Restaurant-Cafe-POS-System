namespace RestaurantPOS.Models
{
    public class FoodItem : MenuItem
    {
        public FoodItem(int productId, string name, decimal unitPrice)
            : base(productId, name, unitPrice) { }

        public override string GetDisplayTag() => "[Food]";
    }
}
