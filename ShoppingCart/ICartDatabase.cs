namespace ShoppingCart.Common
{
    public interface ICartDatabase
    {
        long SaveCart(Cart cart);
    }
}
