using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Reservations.Core.Aggregates;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.BuildingBlocks;

namespace Cine.Reservations.Core.Factories
{
    public interface IReservationsFactory
    {
        Task<Reservation> CreateAsync(EntityId id, CinemaId cinemaId, MovieId movieId, HallId hallId, CustomerId customerId,
            DateTime dateTime, bool isPaymentUponArrival, IEnumerable<Seat> seats, Reservee reservee);
    }
}
