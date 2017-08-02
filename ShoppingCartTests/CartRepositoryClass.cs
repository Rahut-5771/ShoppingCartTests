using NUnit.Framework;
using Moq;
using ShoppingCart.Common;
using System;

namespace ShoppingCartTests
{
    [TestFixture]
    class CartRepositoryClass
    {
        private MockRepository _mockRepository;
        private Mock<ICartDatabase> _cartDatabase;
        private Cart _cart;
        private CartRepository _cartRepository;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _cartDatabase = _mockRepository.Create<ICartDatabase>();
            _cart = new Cart();
            _cartRepository = new CartRepository(_cartDatabase.Object);
        }

        [Test]
        public void RepoCanSaveCart()
        {
            _cartDatabase.Setup(c => c.SaveCart(_cart)).Returns(12345);            
            var result = _cartRepository.SaveCart(_cart);
            Assert.That(result,Is.EqualTo(12345));
        }

        [Test]
        public void ExceptionInSaveCartReturnsZero()
        {
          
            _cartDatabase.Setup(c => c.SaveCart(_cart)).Throws<ApplicationException>();            
            var result = _cartRepository.SaveCart(_cart);
            Assert.That(result, Is.EqualTo(0));
        }

    }

    public class CartRepository
    {
        private ICartDatabase _cartDatabase;

        public CartRepository(ICartDatabase cartDatabase)
        {
            _cartDatabase = cartDatabase;
        }

        public long SaveCart(Cart cart)
        {
            long primaryKey;
            try
            {
                primaryKey = _cartDatabase.SaveCart(cart);
            }
            catch
            {
                primaryKey = 0;
            }
            return primaryKey;
        }
    }
}
