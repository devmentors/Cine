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
    public sealed class ReservationsFactory : IReservationsFactory
    {
        private readonly IReservationSeatsValidator _validator;
        private readonly IReserveesProvider _provider;

        public ReservationsFactory(IReservationSeatsValidator validator, IReserveesProvider provider)
        {
            _validator = validator;
            _provider = provider;
        }

        public async Task<Reservation> CreateAsync(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, CustomerId customerId,
            bool isPaymentUponArrival, IEnumerable<Seat> seats, Reservee reservee)
        {
            var areSeatsValid = await _validator.ValidateAsync(cinemaId, movieId, hallId, seats);

            if (!areSeatsValid)
            {
                throw new SeatsAlreadyReservedException(id);
            }

            if (!customerId.IsEmpty())
            {
                reservee = await _provider.GetAsync(customerId);
            }

            var status = isPaymentUponArrival ? ReservationStatus.PaymentUponArrival : ReservationStatus.Pending;
            var reservation = Reservation.Create(id, cinemaId, movieId, hallId, status, reservee, seats);

            return reservation;
        }
    }
}
