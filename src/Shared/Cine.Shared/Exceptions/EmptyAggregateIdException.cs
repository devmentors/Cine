namespace Cine.Shared.Exceptions
{
    public class EmptyAggregateIdException : DomainException
    {
        public EmptyAggregateIdException() : base(string.Empty)
        {

        }
    }
}
