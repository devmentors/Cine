using System;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Mongo.Documents
{
    public static class Extensions
    {
        public static IdentityDocument AsDocument(this IdentityDto dto, string hashedPassword)
            => new IdentityDocument
            {
                Id = dto.Id,
                Username = dto.Username,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Password = hashedPassword,
                UpdatedAt = DateTime.UtcNow
            };

        public static IdentityDto AsDto(this IdentityDto document)
            => new IdentityDto
            {
                Id = document.Id,
                Username = document.Username,
                FullName = document.FullName,
                Email = document.Email,
                PhoneNumber = document.PhoneNumber,
                UpdatedAt = document.UpdatedAt
            };
    }
}
