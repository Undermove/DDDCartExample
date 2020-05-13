using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DDDCartAppDomain
{
    public class FakeProductRepository : IProductRepository
    {
        private readonly Dictionary<ProductId, Product> _repository;

        public FakeProductRepository()
        {
            var productId = new ProductId(Guid.Empty);
            
            _repository = new Dictionary<ProductId, Product>()
            {
                {productId, new Product(productId, "Kolbasa", 200.0)}
            };
        }

        public Task<Product> GetProduct(ProductId productId)
        {
            return Task.FromResult(_repository[productId]);
        }
    }
}