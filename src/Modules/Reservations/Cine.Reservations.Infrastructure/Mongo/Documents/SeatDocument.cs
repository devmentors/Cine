namespace Cine.Reservations.Infrastructure.Mongo.Documents
{
    public class SeatDocument
    {
        public string Row { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public bool IsVip { get; set; }
    }
}
