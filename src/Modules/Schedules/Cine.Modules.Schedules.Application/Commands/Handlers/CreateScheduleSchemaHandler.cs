using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.Commands.WriteModels;
using Cine.Modules.Schedules.Application.Exceptions;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Shared.Events;

namespace Cine.Modules.Schedules.Application.Commands.Handlers
{
    public sealed class CreateScheduleSchemaHandler : ICommandHandler<CreateScheduleSchema>
    {
        private readonly IScheduleSchemasRepository _repository;
        private readonly IEventProcessor _processor;

        public CreateScheduleSchemaHandler(IScheduleSchemasRepository repository, IEventProcessor processor)
        {
            _repository = repository;
            _processor = processor;
        }

        public async Task HandleAsync(CreateScheduleSchema command)
        {
            var alreadyExists = await _repository.ExistsAsync(command.CinemaId);

            if (alreadyExists)
            {
                throw new ScheduleSchemaAlreadyExistsException(command.CinemaId);
            }

            var scheduleSchema = ScheduleSchema.Create(command.Id, command.CinemaId, command.Times.AsScheduleSchemaTimes());
            await _repository.AddAsync(scheduleSchema);
            await _processor.ProcessAsync(scheduleSchema.DomainEvents);
        }
    }
}
