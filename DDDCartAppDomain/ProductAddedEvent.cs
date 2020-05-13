using EventFlow.Aggregates;

namespace DDDCartAppDomain
{
    public class ProductAddedEvent: IAggregateEvent<Cart, CartId>
    {
        public ProductAddedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}