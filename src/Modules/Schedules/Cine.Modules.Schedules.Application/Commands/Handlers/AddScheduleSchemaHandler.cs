using System.Threading.Tasks;
using Cine.Modules.Schedules.Core.Entities;
using Cine.Modules.Schedules.Core.Repositories;
using Convey.CQRS.Commands;

namespace Cine.Modules.Schedules.Application.Commands.Handlers
{
    public sealed class AddScheduleSchemaHandler : ICommandHandler<AddScheduleSchema>
    {
        private readonly IScheduleSchemasRepository _repository;

        public AddScheduleSchemaHandler(IScheduleSchemasRepository repository)
        {
            _repository = repository;
        }

        public async Task HandleAsync(AddScheduleSchema command)
        {
            var scheduleSchema = new ScheduleSchema(command.Id, command.CinemaId, command.Times.AsScheduleSchemaTimes());
            await _repository.AddAsync(scheduleSchema);
        }
    }
}
