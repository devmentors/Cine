using System;
using System.Windows.Input;

namespace Cine.Reservations.Application.Commands
{
    public class CancelReservation : ICommand
    {
        public Guid Id { get; }

        public CancelReservation(Guid id)
        {
            Id = id;
        }
    }
}
