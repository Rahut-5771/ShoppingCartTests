namespace ShoppingCart
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public string Description { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public CartItem(int quantity, string description, decimal unitPrice)
        {
            Quantity = quantity;
            Description = description;
            UnitPrice = unitPrice;
        }
        public decimal GetItemPrice()
        {
            var price = (Quantity * UnitPrice) - Discount;
            if (price < 0) return 0;
            return price;
        }
        public void ApplyDiscount(decimal discountAmount)
        {
            Discount = discountAmount;
        }
    }
}
