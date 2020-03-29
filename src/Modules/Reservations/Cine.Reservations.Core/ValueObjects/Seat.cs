using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.ValueObjects
{
    public class Seat : ValueObject
    {
        public string Row { get; }
        public int Number { get; }
        public decimal Price { get; }
        public bool IsVip { get; }

        public Seat(string row, int number, decimal price, bool isVip)
        {
            Row = row;
            Number = number;
            Price = price;
            IsVip = isVip;
        }
    }
}
