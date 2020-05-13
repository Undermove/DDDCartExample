using EventFlow.Aggregates.ExecutionResults;
using EventFlow.Commands;
using EventFlow.Core;

namespace DDDCartAppDomain
{
    public class AddProductCommand : Command<Cart, CartId, IExecutionResult>
    {
        public AddProductCommand(CartId aggregateId, ProductId productId) : base(aggregateId)
        {
        }
    }
}