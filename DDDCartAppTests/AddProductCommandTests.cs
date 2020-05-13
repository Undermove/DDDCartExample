using DDDCartAppDomain;
using NUnit.Framework;

namespace DDDCartAppTests
{
    public class AddProductCommandTests
    {
        [Test]
        public void CreateAddProductCommandTest()
        {
            AddProductCommand addProductCommand = new AddProductCommand(CartId.NewCartId(), ProductId.NewProductId());
        }
    }
}