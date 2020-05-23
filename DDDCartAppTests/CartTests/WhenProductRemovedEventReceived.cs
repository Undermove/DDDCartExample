using DDDCartAppDomain;
using DDDCartAppTests.DSL;
using NUnit.Framework;

namespace DDDCartAppTests.CartTests
{
    public class WhenProductRemovedEventReceived
    {
        [Test]
        public void AndCartContainsOneProduct_ThenProductShouldBeRemovedFromCart()
        {
            Product milk = Create.Product().Milk();
            Cart cart = Create.Cart()
                .WithProduct(milk)
                .Please();
            Assert.AreEqual(cart.Products.Count, 1);
            
            ProductRemovedEvent productRemovedEvent = new ProductRemovedEvent(milk);

            cart.Apply(productRemovedEvent);
            
            Assert.AreEqual(cart.Products.Count, 0);
        }
    }
}