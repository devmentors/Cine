using System;
using System.Collections.Generic;
using Convey.Types;

namespace Cine.Modules.Movies.Api.Mongo.Documents
{
    public class MovieDocument : IIdentifiable<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genres { get; set; }
        public int Length { get; set; }
        public DateTime PremiereDate { get; set; }
        public PersonDocument Director { get; set; }
        public IEnumerable<PersonDocument> Stars { get; set; }
        public IEnumerable<RateDocument> Ratings { get; set; }
    }
}
