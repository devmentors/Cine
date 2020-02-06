using System.Linq;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.ValueObjects;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static HallDocument AsDocument(this Hall hall)
            => new HallDocument
            {
                Id = hall.Id,
                CinemaId = hall.CinemaId
            };

        public static Hall AsEntity(this HallDocument document)
            => new Hall(document.Id, document.CinemaId);

        public static ScheduleSchemaDocument AsDocument(this ScheduleSchema schema)
            => new ScheduleSchemaDocument
            {
                Id = schema.Id,
                CinemaId = schema.CinemaId,
                Hours = schema.Hours
            };

        public static ScheduleSchema AsEntity(this ScheduleSchemaDocument document)
            => new ScheduleSchema(document.Id, document.CinemaId, new ScheduleSchemaHours(document.Hours));

        public static ScheduleDocument AsDocument(this Schedule entity)
            => new ScheduleDocument
            {
                Id = entity.Id,
                CinemaId = entity.CinemaId,
                MovieId = entity.MovieId,
                Reservations = entity.Reservations.Select(r => new ReservationDocument
                {
                    HallId = r.HallId
                })
            };

        public static Schedule AsEntity(this ScheduleDocument document)
        {
            var reservations = document.Reservations
                .Select(r => new Reservation(r.HallId, r.Date, new ScheduleTime(r.Time.Hour, r.Time.Minute)));

            return new Schedule(document.Id, document.CinemaId, document.MovieId, reservations);
        }
    }
}
