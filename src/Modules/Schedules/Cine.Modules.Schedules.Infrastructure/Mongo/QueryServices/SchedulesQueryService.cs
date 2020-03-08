using System;
using System.Linq;
using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.DTO;
using Cine.Modules.Schedules.Application.Services;
using Cine.Modules.Schedules.Infrastructure.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.QueryServices
{
    internal sealed class SchedulesQueryService : ISchedulesQueryService
    {
        private readonly IMongoRepository<ScheduleDocument, Guid> _repository;

        public SchedulesQueryService(IMongoRepository<ScheduleDocument, Guid> repository)
            => _repository = repository;

        public async Task<ScheduleDto> GetWeeklyScheduleAsync(Guid cinemaId, Guid movieId)
        {
            var document = await _repository.GetAsync(s => s.CinemaId == cinemaId && s.MovieId == movieId);

            if (document is null)
            {
                return null;
            }

            var dto = document.AsDto();
            dto.Reservations = dto.Reservations.Where(r => r.DateTime <= DateTime.UtcNow.AddDays(7));
            return dto;
        }
    }
}
