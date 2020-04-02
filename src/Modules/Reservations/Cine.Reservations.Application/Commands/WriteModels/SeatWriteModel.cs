namespace Cine.Reservations.Application.Commands.WriteModels
{
    public class SeatWriteModel
    {
        public string Row { get; }
        public int Number { get; }
        public decimal Price { get; }
        public bool IsVip { get; }

        public SeatWriteModel(string row, int number, decimal price, bool isVip)
        {
            Row = row;
            Number = number;
            Price = price;
            IsVip = isVip;
        }
    }
}
