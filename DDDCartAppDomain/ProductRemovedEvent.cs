namespace DDDCartAppDomain
{
    public class ProductRemovedEvent
    {
        public ProductRemovedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}