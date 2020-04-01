using Cine.Shared.BuildingBlocks;
using Cine.Shared.Kernel.ValueObjects;

namespace Cine.Reservations.Core.ValueObjects
{
    public class Reservee : ValueObject
    {
        public string FullName { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }

        public Reservee(string fullName, Email email, PhoneNumber phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
