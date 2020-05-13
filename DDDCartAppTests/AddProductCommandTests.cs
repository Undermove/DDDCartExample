using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests
{
    public class AddProductCommandTests
    {
        [Test]
        public void CreateAddProductCommandTest()
        {
            var productId = ProductId.NewProductId();

            AddProductCommand addProductCommand = new AddProductCommand(CartId.NewCartId(), productId);

            Assert.AreEqual(productId, addProductCommand.ProductId);
        }
    }
}