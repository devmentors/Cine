using System.Threading.Tasks;
using Cine.Modules.Schedules.Application.Commands.WriteModels;
using Cine.Modules.Schedules.Core.Aggregates;
using Cine.Modules.Schedules.Core.Repositories;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands.Handlers
{
    public sealed class CreateScheduleSchemaHandler : ICommandHandler<CreateScheduleSchema>
    {
        private readonly IScheduleSchemasRepository _repository;

        public CreateScheduleSchemaHandler(IScheduleSchemasRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(CreateScheduleSchema command)
        {
            var scheduleSchema = new ScheduleSchema(command.Id, command.CinemaId, command.Times.AsScheduleSchemaTimes());
            await _repository.AddAsync(scheduleSchema);
        }
    }
}
