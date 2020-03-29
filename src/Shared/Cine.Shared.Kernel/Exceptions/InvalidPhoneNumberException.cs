using Cine.Shared.Exceptions;

namespace Cine.Shared.Kernel.Exceptions
{
    public class InvalidPhoneNumberException : DomainException
    {
        public override string ErrorCode => "invalid_phone_number";

        public InvalidPhoneNumberException(string phoneNumber) : base($"Invalid phone number: {phoneNumber}")
        {
        }
    }
}
