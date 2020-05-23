using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCartAppDomain
{
    public class RemoveProductCommandHandler : CommandHandler<Cart, CartId, IExecutionResult, RemoveProductCommand>
    {
        private IProductRepository _productRepository;
        
        public RemoveProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        public override async Task<IExecutionResult> ExecuteCommandAsync(Cart aggregate, RemoveProductCommand command, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetProduct(command.ProductId);

            if (product == null)
            {
                return ExecutionResult.Failed();
            }
            
            aggregate.RemoveProduct(product);

            return ExecutionResult.Success();
        }
    }
}