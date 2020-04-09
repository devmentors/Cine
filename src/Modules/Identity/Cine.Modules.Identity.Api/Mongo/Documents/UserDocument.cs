using System;
using Convey.Types;

namespace Cine.Modules.Identity.Api.Mongo.Documents
{
    public class UserDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
