using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCartAppDomain
{
    public class RemoveProductCommand : Command<Cart, CartId, IExecutionResult>
    {
        public RemoveProductCommand(CartId aggregateId, ProductId productId) : base(aggregateId)
        {
            ProductId = productId;
        }
        
        public ProductId ProductId { get; }
    }
}