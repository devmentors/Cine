using System;
using System.Linq;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Mongo.Documents;

namespace Cine.Modules.Movies.Api.Mongo
{
    public static class Extensions
    {
        public static MovieDto AsDto(this MovieDocument document)
            => new MovieDto
            {
                Id = document.Id,
                Title = document.Title,
                Description = document.Description,
                AgeRestriction = document.AgeRestriction,
                Length = document.Length,
                PremiereDate = document.PremiereDate,
                Genre = document.Genre.ToString(),
                Director = new PersonDto
                {
                    FirstName = document.Director?.FirstName,
                    LastName = document.Director?.LastName
                },
                Stars = document.Stars?.Select(s => new PersonDto
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }),
                Ratings = document.Ratings?.Select(r => new RateDto
                {
                    Comment = r.Comment,
                    Value = r.Value
                })
            };

        public static MovieDocument AsDocument(this MovieDto dto)
            => new MovieDocument
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                AgeRestriction = dto.AgeRestriction,
                Length = dto.Length,
                PremiereDate = dto.PremiereDate,
                Genre = Enum.TryParse<Genre>(dto.Genre, ignoreCase: true, out var genre) ? genre : Genre.None,
                Director = new PersonDocument
                {
                    FirstName = dto.Director?.FirstName,
                    LastName = dto.Director?.LastName
                },
                Stars = dto.Stars?.Select(s => new PersonDocument
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName
                }),
                Ratings = dto.Ratings?.Select(r => new RateDocument
                {
                    Comment = r.Comment,
                    Value = r.Value
                })
            };
    }
}
