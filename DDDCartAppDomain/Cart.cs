using System;
using System.Collections.Generic;
using EventFlow.Aggregates;

namespace DDDCartAppDomain
{
  public class Cart : AggregateRoot<Cart, CartId>
  {
    private readonly List<Product> _products;

    public Cart(CartId id) : base(id)
    {
      _products = new List<Product>();
    }

    public List<Product> Products => _products;

    public void Apply(ProductAddedEvent addProductEvent)
    {
      _products.Add(addProductEvent.Product);
    }

        internal void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}