using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;

namespace DDDCartAppDomain
{
    public class AddProductCommand : Command<Cart, CartId, IExecutionResult>
    {
        public AddProductCommand(CartId aggregateId, ProductId productId) : base(aggregateId)
        {
            ProductId = productId;
        }

        public ProductId ProductId { get; }
    }
}