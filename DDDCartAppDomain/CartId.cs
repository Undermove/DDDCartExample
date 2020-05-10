using EventFlow.Core;

namespace DDDCartAppDomain
{
    public class CartId : Identity<CartId>
    {
        public CartId(string value) : base(value)
        {
        }
    }
}