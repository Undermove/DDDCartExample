using System;
using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests
{
	public class CartTests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void WhenAddProductToCartEventReceived_ThenProductShouldBeAdded()
		{
			CartId id = new CartId($"cart-{Guid.NewGuid()}"); 
			Cart cart = new Cart(id);
			AddProductEvent addProductEvent = new AddProductEvent();

			cart.Apply(addProductEvent);

			Assert.NotNull(cart.Products, "Products property should not be bull by default");
			Assert.True(cart.Products.Count == 1);
		}
	}
}