namespace Cine.Shared.Exceptions
{
    public class EmptyAggregateIdException : DomainException
    {
        public override string ErrorCode => "empty_aggregate_id";

        public EmptyAggregateIdException() : base(string.Empty)
        {

        }

    }
}
