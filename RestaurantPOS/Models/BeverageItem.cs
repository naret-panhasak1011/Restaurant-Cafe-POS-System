namespace RestaurantPOS.Models
{
    public class BeverageItem : MenuItem
    {
        public BeverageItem(int productId, string name, decimal unitPrice)
            : base(productId, name, unitPrice) { }

        public override string GetDisplayTag() => "[Beverage]";
    }
}
