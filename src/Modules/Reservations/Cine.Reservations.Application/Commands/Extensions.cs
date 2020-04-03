using System.Collections.Generic;
using System.Linq;
using Cine.Reservations.Application.Commands.WriteModels;
using Cine.Reservations.Core.ValueObjects;

namespace Cine.Reservations.Application.Commands
{
    public static class Extensions
    {
        public static IEnumerable<Seat> AsValueObjects(this IEnumerable<SeatWriteModel> seats)
            => seats.Select(s => new Seat(s.Row, s.Number, s.Price, s.IsVip));

        public static Reservee AsValueObject(this ReserveeWriteModel reservee)
            => reservee is null ? null : new Reservee(reservee.FullName, reservee.Email, reservee.PhoneNumber);
    }
}
