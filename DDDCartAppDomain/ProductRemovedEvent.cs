using EventFlow.Aggregates;
using EventFlow.Entities;

namespace DDDCartAppDomain
{
    public class ProductRemovedEvent : IAggregateEvent<Cart, CartId>
    {
        public ProductRemovedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
    }
}