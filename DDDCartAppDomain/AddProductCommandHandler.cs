using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCartAppDomain
{
    public class AddProductCommandHandler : CommandHandler<Cart, CartId, IExecutionResult, AddProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<IExecutionResult> ExecuteCommandAsync(Cart aggregate, AddProductCommand command, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetProduct(command.ProductId);

            if (product == null)
            {
               return ExecutionResult.Failed();
            }
            
            aggregate.AddProduct(product);

            return ExecutionResult.Success();
        }
    }
}