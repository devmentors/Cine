using Cine.Reservations.Core.Aggregates;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Events
{
    public class ReservationPriceChanged : IDomainEvent
    {
        public Reservation Reservation { get; }
        public decimal Price { get; }

        public ReservationPriceChanged(Reservation reservation, decimal price)
        {
            Reservation = reservation;
            Price = price;
        }
    }
}
