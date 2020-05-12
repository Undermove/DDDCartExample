using System;

namespace DDDCartAppDomain
{
    public class Product
    {
        public ProductId Id { get; }
        public string Name { get; }
        public double Price { get; }

        public Product(ProductId id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}