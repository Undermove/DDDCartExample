using System.Security.Cryptography;
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
            
            Assert.AreEqual(0, cart.Products.Count);
        }

        [Test]
        public void AndCartContainsAnotherProduct_ThenProductShouldNotBeRemoved()
        {
            Product milk = Create.Product().Milk();
            Cart cart = Create.Cart()
                .WithProduct(milk)
                .Please();
            Assert.AreEqual(cart.Products.Count, 1);
            Product meatballs = Create.Product().MeatBalls();
            ProductRemovedEvent productRemovedEvent = new ProductRemovedEvent(meatballs);
            
            cart.Apply(productRemovedEvent);
            
            Assert.AreEqual(1, cart.Products.Count);
            Assert.AreEqual(milk, cart.Products[0]);
        }
    }
}