using System.Collections.Generic;
using System.Linq;
using Cine.Modules.Schedules.Application.DTO;
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
                }),
                Version = schema.Version
            };

        public static ScheduleDocument AsDocument(this Schedule schedule)
            => new ScheduleDocument
            {
                Id = schedule.Id,
                CinemaId = schedule.CinemaId,
                MovieId = schedule.MovieId,
                Shows = schedule.Shows.Select(s => new ShowDocument
                {
                    HallId = s.HallId,
                    DateTime = s.Date.AddHours(s.Time.Hour).AddMinutes(s.Time.Minute)
                }),
                Version = schedule.Version
            };

        public static Hall AsEntity(this HallDocument document)
            => new Hall(document.Id, document.CinemaId);

        public static ScheduleSchema AsEntity(this ScheduleSchemaDocument document)
            => new ScheduleSchema(document.Id, document.CinemaId, new ScheduleSchemaTimes(document.Times.AsEntity()), document.Version);

        public static Schedule AsEntity(this ScheduleDocument document)
        {
            var shows = document.Shows
                .Select(s => new Show(s.HallId, s.DateTime.Date, new Time(s.DateTime.Hour, s.DateTime.Minute)));

            return new Schedule(document.Id, document.CinemaId, document.MovieId, shows, document.Version);
        }

        public static ScheduleDto AsDto(this ScheduleDocument document)
            => new ScheduleDto
            {
                Id = document.Id,
                CinemaId = document.CinemaId,
                MovieId = document.MovieId,
                Shows = document.Shows.Select(s => new ShowDto
                {
                    HallId = s.HallId,
                    DateTime = s.DateTime
                })
            };

        private static ScheduleSchemaTimes AsEntity(this IEnumerable<ScheduleSchemaTimesDocument> document)
            => new ScheduleSchemaTimes(document.Select(d =>
                (d.AgeRestriction, d.Times.Select(t => new Time(t.Hour, t.Minute)))));
    }
}
