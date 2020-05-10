namespace DDDCartAppDomain
{
    public class ProductAddedEvent
    {
        public ProductAddedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}