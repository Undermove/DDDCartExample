using System;
using System.Diagnostics.CodeAnalysis;

namespace DDDCartAppDomain
{
    public class ProductId : IEquatable<ProductId>
    {
        private readonly Guid _id;

        public ProductId(Guid id)
        {
            _id = id;
        }

        public static ProductId NewProductId()
        {
            return new ProductId(Guid.NewGuid());
        }

        public bool Equals(ProductId other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            return _id.Equals(other._id);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj)) return false;
            if(ReferenceEquals(this, obj)) return true;
            if(obj.GetType() != this.GetType()) return false;
            return Equals((ProductId) obj);
        }

        public static bool operator ==(ProductId left, ProductId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProductId left, ProductId right)
        {
            return !Equals(left, right);
        }
    }
}