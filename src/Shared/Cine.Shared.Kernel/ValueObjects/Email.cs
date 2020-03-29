using System.ComponentModel.DataAnnotations;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.Kernel.Exceptions;

namespace Cine.Shared.Kernel.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; }

        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new InvalidEmailException(email);
            }

            if (email.Length > 100)
            {
                throw new InvalidEmailException(email);
            }

            if (new EmailAddressAttribute().IsValid(email))
            {
                throw new InvalidEmailException(email);
            }

            Value = email.ToLowerInvariant();
        }

        public static implicit operator string(Email email) => email.Value;

        public static implicit operator Email(string email) => new Email(email);

        public override string ToString() => Value;
    }
}
