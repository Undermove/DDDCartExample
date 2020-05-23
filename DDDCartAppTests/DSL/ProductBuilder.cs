using DDDCartAppDomain;

namespace DDDCartAppTests.DSL
{
    public class ProductBuilder
    {
        public Product Milk()
        {
            return new Product(ProductId.NewProductId(), "Milk", 80);
        }
    }
}