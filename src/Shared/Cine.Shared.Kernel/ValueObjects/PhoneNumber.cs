using System;
using System.Text.RegularExpressions;
using Cine.Shared.BuildingBlocks;
using Cine.Shared.Kernel.Exceptions;

namespace Cine.Shared.Kernel.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; }

        public PhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new InvalidPhoneNumberException(phoneNumber);
            }

            if (!Regex.IsMatch(phoneNumber, @"^(\+[0-9]{9})$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)))
            {
                throw new InvalidPhoneNumberException(phoneNumber);
            }

            Value = phoneNumber.ToLowerInvariant();
        }

        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

        public static implicit operator PhoneNumber(string phoneNumber) => new PhoneNumber(phoneNumber);

        public override string ToString() => Value;
    }
}
