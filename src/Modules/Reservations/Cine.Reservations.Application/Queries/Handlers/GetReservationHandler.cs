using System.Threading.Tasks;
using Cine.Reservations.Application.DTO;
using Cine.Reservations.Application.Services;
using Cine.Shared.Queries;

namespace Cine.Reservations.Application.Queries.Handlers
{
    public sealed class GetReservationHandler : IQueryHandler<GetReservation, ReservationDto>
    {
        private readonly IReservationsQueryService _queryService;

        public GetReservationHandler(IReservationsQueryService queryService)
            => _queryService = queryService;

        public Task<ReservationDto> HandleAsync(GetReservation query)
            => _queryService.GetAsync(query.ReservationId);
    }
}
