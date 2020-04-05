using System;
using Convey.CQRS.Commands;

namespace Cine.Reservations.Application.Commands
{
    public class CompleteReservation : ICommand
    {
        public Guid Id { get; }

        public CompleteReservation(Guid id)
        {
            Id = id;
        }
    }
}
