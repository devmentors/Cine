namespace Cine.Reservations.Application.DTO
{
    public class SeatDto
    {
        public string Row { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public bool IsVip { get; set; }
    }
}
