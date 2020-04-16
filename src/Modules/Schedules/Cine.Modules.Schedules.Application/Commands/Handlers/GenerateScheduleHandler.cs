using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.Exceptions;
using Cine.Modules.Schedules.Application.Services.Clients;
using Cine.Modules.Schedules.Core.Policies;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Shared.Events;

namespace Cine.Modules.Schedules.Application.Commands.Handlers
{
    public sealed class GenerateScheduleHandler : ICommandHandler<GenerateSchedule>
    {
        private readonly IMoviesApiClient _client;
        private readonly ISchedulePolicy _policy;
        private readonly ISchedulesRepository _repository;
        private readonly IEventProcessor _processor;

        public GenerateScheduleHandler(IMoviesApiClient client, ISchedulePolicy policy, ISchedulesRepository repository,
            IEventProcessor processor)
        {
            _client = client;
            _policy = policy;
            _repository = repository;
            _processor = processor;
        }

        public async Task HandleAsync(GenerateSchedule command)
        {
            var alreadyExists = await _repository.ExistsAsync(command.CinemaId, command.MovieId);

            if (alreadyExists)
            {
                throw new ScheduleAlreadyExistsException(command.CinemaId, command.MovieId);
            }

            var movie = await _client.GetAsync(command.MovieId);

            if (movie is null)
            {
                throw new MovieNotFoundException(command.MovieId);
            }

            var schedule = await _policy.GenerateScheduleAsync(command.Id, command.CinemaId, command.MovieId,
                command.From, command.To, movie.AgeRestriction);

            await _repository.AddAsync(schedule);
            await _processor.ProcessAsync(schedule.DomainEvents);
        }
    }
}
