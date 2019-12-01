using System;

namespace Cinema.Shared.BuildingBlocks
{
    public abstract class TypedId : IEquatable<TypedId>
    {
        public Guid Value { get; }

        protected TypedId(Guid value)
            => Value = value;

        public bool IsEmpty() => Value == Guid.Empty;

        public bool Equals(TypedId other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((TypedId) obj);
        }

        public override int GetHashCode()
            => Value.GetHashCode();

        public static implicit operator Guid(TypedId typedId)
            => typedId.Value;

        public static bool operator ==(TypedId a, TypedId b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if(!(a is null) && !(b is null))
                return a.Value.Equals(b.Value);

            return false;
        }

        public static bool operator !=(TypedId a, TypedId b)
            => !(a == b);

        public override string ToString() => Value.ToString();
    }
}
