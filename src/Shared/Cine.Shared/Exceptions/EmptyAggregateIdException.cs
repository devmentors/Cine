namespace Cinema.Shared.Exceptions
{
    public class EmptyAggregateIdException : DomainException
    {
        public EmptyAggregateIdException() : base(string.Empty)
        {

        }
    }
}
