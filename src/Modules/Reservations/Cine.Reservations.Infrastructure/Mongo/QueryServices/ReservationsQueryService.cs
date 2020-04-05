using System;
using System.Threading.Tasks;
using Cine.Reservations.Application.DTO;
using Cine.Reservations.Application.Services;
using Cine.Reservations.Infrastructure.Mongo.Documents;
using Convey.Persistence.MongoDB;

namespace Cine.Reservations.Infrastructure.Mongo.QueryServices
{
    internal sealed class ReservationsQueryService : IReservationsQueryService
    {
        private readonly IMongoRepository<ReservationDocument, Guid> _repository;

        public ReservationsQueryService(IMongoRepository<ReservationDocument, Guid> repository)
            => _repository = repository;

        public async Task<ReservationDto> GetAsync(Guid id)
        {
            var document = await _repository.GetAsync(id);
            return document?.AsDocument();
        }
    }
}
