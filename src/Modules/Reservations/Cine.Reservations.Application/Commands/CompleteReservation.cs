using System;
using System.Windows.Input;

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
