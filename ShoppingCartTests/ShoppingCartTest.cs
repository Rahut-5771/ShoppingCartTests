using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShoppingCart.Common;

namespace ShoppingCartTests
{
    [TestFixture]
    class ShoppingCartTest
    {
        private Cart _cart;
        private CartItem _item;
        private CartItem _item2;

        [SetUp]
        public void SetUp()
        {
            _cart = new Cart();
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
}
