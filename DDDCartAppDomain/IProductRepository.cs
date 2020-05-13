using System.Threading.Tasks;

namespace DDDCartAppDomain
{
    public interface IProductRepository
    {
        Task<Product> GetProduct(ProductId productId);
    }
}