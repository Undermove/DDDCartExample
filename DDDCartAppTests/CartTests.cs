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
			_product = new Product(productId, "Milk", 90);
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
			Assert.AreEqual(_product.Id, cartProduct.Id);
		}

		[Test]
		public void WhenProductAddedEventReceived_ThenCartProductNameShouldBeEqualWithProductNameFromEvent()
		{
			ProductAddedEvent addProductEvent = new ProductAddedEvent(_product);

			_cart.Apply(addProductEvent);

			var cartProduct = _cart.Products.First();
			Assert.NotNull(cartProduct.Name);
			Assert.AreEqual(_product.Name, cartProduct.Name);
		}

		[Test]
		public void WhenProductAddedEventReceived_ThenCartProductPriceShouldBeEqualWithProductPriceFromEvent()
		{
			ProductAddedEvent productAdded = new ProductAddedEvent(_product);

			_cart.Apply(productAdded);
			
			Assert.AreEqual(_product.Price, _cart.Products.First().Price);
		}

		[Test]
		public void WhenTwoProductAddedEventsReceived_ThenCartShouldContainTwoProducts()
		{
			ProductAddedEvent firstProductAddedEvent = new ProductAddedEvent(_product);
			ProductAddedEvent secondProductAddedEvent = new ProductAddedEvent(_product);

			_cart.Apply(firstProductAddedEvent);
			_cart.Apply(secondProductAddedEvent);

			Assert.NotNull(_cart.Products);
			Assert.AreEqual(2, _cart.Products.Count);
		}
	}
}