using System;

namespace DDDCartAppDomain
{
    public class ProductId
    {
        private readonly Guid _id;

        public ProductId(Guid id)
        {
            _id = id;
        }
    }
}