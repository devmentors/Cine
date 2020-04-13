using System;
using System.ComponentModel.DataAnnotations.Schema;
using Convey.Types;

namespace Cine.Modules.Identity.Api.Mongo.Documents
{
    public class RefreshTokenDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevokedAt { get; set; }

        [NotMapped]
        public bool IsRevoked => RevokedAt.HasValue;
    }
}
