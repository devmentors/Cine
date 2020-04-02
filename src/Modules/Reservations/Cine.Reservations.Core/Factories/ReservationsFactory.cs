using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.Events;
using Cine.Reservations.Core.Exceptions;
using Cine.Reservations.Core.Services;
using Cine.Reservations.Core.Types;
using Cine.Reservations.Core.Validators;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Factories
{
    internal sealed class ReservationsFactory : IReservationsFactory
    {
        private readonly IReservationSeatsValidator _validator;
        private readonly IReserveesService _service;

        public ReservationsFactory(IReservationSeatsValidator validator, IReserveesService service)
        {
            _validator = validator;
            _service = service;
        }

        public async Task<Reservation> CreateAsync(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, CustomerId customerId,
            bool isPaymentUponArrival, IEnumerable<Seat> seats, Reservee reservee)
        {
            var areSeatsValid = await _validator.ValidateAsync(seats);

            if (!areSeatsValid)
            {
                throw new SeatsAlreadyReservedException(id);
            }

            if (!customerId.IsEmpty())
            {
                reservee = await _service.GetAsync(customerId);
            }

            var status = isPaymentUponArrival ? ReservationStatus.PaymentUponArrival : ReservationStatus.Pending;
            var reservation = new Reservation(id, cinemaId, movieId, hallId, status, reservee, seats);
            reservation.ClearEvents();
            reservation.AddDomainEvent(new ReservationAdded(reservation));

            return reservation;
        }
    }
}
