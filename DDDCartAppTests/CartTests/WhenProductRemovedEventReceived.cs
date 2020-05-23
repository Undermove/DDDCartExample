using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests.CartTests
{
    public class WhenProductRemovedEventReceived
    {
        [Test]
        public void AndCartContainsOneProduct_ThenProductShouldBeRemovedFromCart()
        {
            Cart cart = new Cart(CartId.NewCartId());
            Product product = new Product(ProductId.NewProductId(), "Milk", 80);
            ProductAddedEvent productAddedEvent = new ProductAddedEvent(product);
            cart.Apply(productAddedEvent);
            Assert.AreEqual(cart.Products.Count, 1);
            
            ProductRemovedEvent productRemovedEvent = new ProductRemovedEvent(product);

            cart.Apply(productRemovedEvent);
            
            Assert.AreEqual(cart.Products.Count, 0);
        }
    }
}