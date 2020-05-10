using System;

namespace DDDCartAppDomain
{
    public class Product
    {
        public ProductId Id { get; }

        public Product(ProductId id)
        {
            Id = id;
        }
    }
}