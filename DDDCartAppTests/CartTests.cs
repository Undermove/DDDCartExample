using System;
using System.Linq;
using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests
{
	public class CartTests
	{
		private Cart _cart;
		private Product _product;

		[SetUp]
		public void Setup()
		{
			CartId cartId = new CartId($"cart-{Guid.NewGuid()}"); 
			_cart = new Cart(cartId);
			ProductId productId = new ProductId(Guid.NewGuid());
			_product = new Product(productId, "Milk");
		}

		[Test]
		public void WhenProductAddedEventReceived_ThenCartShouldContainOneProduct()
		{
			ProductAddedEvent addProductEvent = new ProductAddedEvent(_product);

			_cart.Apply(addProductEvent);

			Assert.NotNull(_cart.Products, "Products property should not be null by default");
			Assert.True(_cart.Products.Count == 1);
		}

		[Test]
		public void WhenProductAddedEventReceived_ThenCartProductIdShouldBeEqualWithProductIdFromEvent()
		{
			ProductAddedEvent addProductEvent = new ProductAddedEvent(_product);

			_cart.Apply(addProductEvent);

			var cartProduct = _cart.Products.First();
			Assert.NotNull(cartProduct.Id);
			Assert.True(cartProduct.Id == _product.Id);
		}

		[Test]
		public void WhenProductAddedEventReceived_ThenCartProductNameShouldBeEqualWithProductNameFromEvent()
		{
			ProductAddedEvent addProductEvent = new ProductAddedEvent(_product);

			_cart.Apply(addProductEvent);

			var cartProduct = _cart.Products.First();
			Assert.NotNull(cartProduct.Name);
			Assert.True(cartProduct.Name == _product.Name);
		}
	}
}