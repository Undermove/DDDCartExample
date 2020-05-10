using System;
using System.Linq;
using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests
{
	public class CartTests
	{
		private Cart _cart;

		[SetUp]
		public void Setup()
		{
			CartId cartId = new CartId($"cart-{Guid.NewGuid()}"); 
			_cart = new Cart(cartId);
		}

		[Test]
		public void WhenAddProductToCartEventReceived_ThenCartShouldContainOneProduct()
		{
			AddProductEvent addProductEvent = new AddProductEvent();

			_cart.Apply(addProductEvent);

			Assert.NotNull(_cart.Products, "Products property should not be bull by default");
			Assert.True(_cart.Products.Count == 1);
		}

		// [Test]
		// public void WhenAddProductToCartEventReceived_ThenCartProductIdShouldBeEqualWithProductIdFromEvent()
		// {
			
		// 	var cartProduct = cart.Products.First();
		// 	Assert.NotNull(cartProduct.Id);
		// 	Assert.True(cartProduct.Id == productId);
		// }
	}
}