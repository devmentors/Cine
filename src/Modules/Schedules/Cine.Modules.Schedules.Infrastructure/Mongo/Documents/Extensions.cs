using System;
using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Types;
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
                Times = schema.Times?.Select(st => new ScheduleSchemaTimesDocument
                {
                    AgeRestriction = st.ageRestriction,
                    Times = st.times?.Select(t => new TimeDocument
                    {
                        Hour = t.Hour,
                        Minute = t.Minute
                    })
                })
            };

        public static ScheduleSchema AsEntity(this ScheduleSchemaDocument document)
            => new ScheduleSchema(document.Id, document.CinemaId, new ScheduleSchemaTimes(document.Times.AsEntity()));

        public static ScheduleDocument AsDocument(this Schedule entity)
            => new ScheduleDocument
            {
                Id = entity.Id,
                CinemaId = entity.CinemaId,
                MovieId = entity.MovieId,
                Reservations = entity.Reservations.Select(r => new ReservationDocument
                {
                    HallId = r.HallId,
                    DateTime = r.Date.AddHours(r.Time.Hour).AddMinutes(r.Time.Minute)
                })
            };

        public static Schedule AsEntity(this ScheduleDocument document)
        {
            var reservations = document.Reservations
                .Select(r => new Reservation(r.HallId, r.DateTime.Date, new Time(r.DateTime.Hour, r.DateTime.Minute)));

            return new Schedule(document.Id, document.CinemaId, document.MovieId, reservations);
        }

        private static ScheduleSchemaTimes AsEntity(this IEnumerable<ScheduleSchemaTimesDocument> document)
            => new ScheduleSchemaTimes(document.Select(d =>
                (d.AgeRestriction, d.Times.Select(t => new Time(t.Hour, t.Minute)))));
    }
}
