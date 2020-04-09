using System;
using Cine.Modules.Identity.Api.DTO;

namespace Cine.Modules.Identity.Api.Mongo.Documents
{
    public static class Extensions
    {
        public static UserDocument AsDocument(this UserDto dto, string hashedPassword)
            => new UserDocument
            {
                Id = dto.Id,
                Username = dto.Username,
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Password = hashedPassword,
                UpdatedAt = DateTime.UtcNow
            };

        public static UserDto AsDto(this UserDto document)
            => new UserDto
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
