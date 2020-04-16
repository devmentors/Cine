namespace Cine.Shared.Mongo
{
    public interface IIdentifiable<out TKey>
    {
        TKey Id { get; }
    }
}
