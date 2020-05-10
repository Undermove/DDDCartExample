using System;

namespace DDDCartAppDomain
{
    public class Product
    {
        public ProductId Id { get; }
        public string Name { get; }

        public Product(ProductId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}