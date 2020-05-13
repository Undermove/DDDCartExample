using System;
using EventFlow.Core;

namespace DDDCartAppDomain
{
    public class CartId : Identity<CartId>
    {
        public CartId(string value) : base(value)
        {
        }

        public static CartId NewCartId()
        {
            return new CartId($"cart-{Guid.NewGuid()}");
        }
    }
}