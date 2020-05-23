using DDDCartAppDomain;

namespace DDDCartAppTests.DSL
{
    public class ProductBuilder
    {
        public Product Milk()
        {
            return new Product(ProductId.NewProductId(), "Milk", 80);
        }

        public Product MeatBalls()
        {
            return new Product(ProductId.NewProductId(), "Meatballs", 200);
        }
    }
}