using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.Commands.WriteModels;
using Cine.Modules.Schedules.Application.Exceptions;
using Cine.Modules.Schedules.Core.Repositories;
using Cine.Shared.Events;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands.Handlers
{
    public sealed class UpdateScheduleSchemaHandler : ICommandHandler<UpdateScheduleSchema>
    {
        private readonly IScheduleSchemasRepository _repository;
        private readonly IEventProcessor _processor;

        public UpdateScheduleSchemaHandler(IScheduleSchemasRepository repository, IEventProcessor processor)
        {
            _repository = repository;
            _processor = processor;
        }

        public async Task HandleAsync(UpdateScheduleSchema command)
        {
            var schema = await _repository.GetAsync(command.Id);

            if (schema is null)
            {
                throw new ScheduleSchemaNotFoundException(command.Id);
            }

            schema.ChangeTimes(command.Times.AsScheduleSchemaTimes());

            await _repository.UpdateAsync(schema);
            await _processor.ProcessAsync(schema.DomainEvents);
        }
    }
}
