using System;
using Convey.CQRS.Commands;

namespace Cine.Modules.Identity.Api.Commands
{
    public class SignUp : ICommand
    {
        public Guid Id { get; }
        public string Username { get; }
        public string FullName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string Password { get; }

        public SignUp(Guid id, string username, string fullName, string email, string phoneNumber, string password)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}
