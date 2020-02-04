using Cine.Modules.Schedules.Core.Entities;

namespace Cine.Modules.Schedules.Infrastructure.Mongo.Documents
{
    internal static class Extensions
    {
        public static HallDocument AsDocument(this Hall hall)
            => new HallDocument
            {
                Id = hall.Id
            };

        public static Hall AsEntity(this HallDocument document)
            => new Hall(document.Id);
    }
}
