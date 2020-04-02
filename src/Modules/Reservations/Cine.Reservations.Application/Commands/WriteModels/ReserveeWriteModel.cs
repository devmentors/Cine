using Cine.Shared.Kernel.ValueObjects;

namespace Cine.Reservations.Application.Commands.WriteModels
{
    public class ReserveeWriteModel
    {
        public string FullName { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }

        public ReserveeWriteModel(string fullName, Email email, PhoneNumber phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
