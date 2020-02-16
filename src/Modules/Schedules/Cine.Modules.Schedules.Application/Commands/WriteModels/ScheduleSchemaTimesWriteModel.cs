using System.Collections.Generic;

namespace Cine.Modules.Schedules.Application.Commands.WriteModels
{
    public class ScheduleSchemaTimesWriteModel
    {
        public int AgeRestriction { get; }
        public IEnumerable<TimeWriteModel> Times { get; }

        public ScheduleSchemaTimesWriteModel(int ageRestriction, IEnumerable<TimeWriteModel> times)
        {
            AgeRestriction = ageRestriction;
            Times = times;
        }
    }
}
