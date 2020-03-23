using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.ValueObjects
{
    public class Seat : ValueObject
    {
        public string Row { get; }
        public int Number { get; }
        public bool IsVip { get; }

        public Seat(string row, int number, bool isVip)
        {
            Row = row;
            Number = number;
            IsVip = isVip;
        }
    }
}
