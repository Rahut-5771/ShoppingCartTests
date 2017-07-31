using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShoppingCart;

namespace ShoppingCartTests
{
    [TestFixture]
    class ShoppingCartTest
    {
        private ShoppingCart _cart;
        private CartItem _item;
        private CartItem _item2;

        [SetUp]
        public void SetUp()
        {
            _cart = new ShoppingCart();
            _item = new CartItem(2, "Test", 1.00m);
            _item2 = new CartItem(3, "Test", 2.00m);
        }
         
        [Test]
        public void ShoppingCartCanContainZeroItem()
        {
            Assert.That(_cart.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void ShoppingCartCanAddItem()
        {
            _cart.AddItem(_item);
            Assert.That(_cart.Items, Has.Member(_item));
        }

        [Test]
        public void CartContainsNoDuplicateItem()
        {
            _cart.AddItem(_item);
            _cart.AddItem(_item);
            Assert.That(_cart.Items.Count,Is.EqualTo(1));
        }

        [Test]
        public void CartRemoveItem()
        {
            _cart.AddItem(_item);
            _cart.RemoveItem(_item);

            Assert.That(_cart.Items.Count, Is.EqualTo(0));
        }

        [Test]
        public void GetTotalShoppingCartPrice()
        {
            _cart.AddItem(_item);
            _cart.AddItem(_item2);

            Assert.That(_cart.GetShoppingCartTotal(),Is.EqualTo(8.00m));
        }
    }

    public class ShoppingCart
    {
        public List<CartItem> Items { get; private set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            if (Items.Contains(item))
                return;
            Items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        public decimal GetShoppingCartTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.GetItemPrice();
            }
            return total;
        }
    }
}
