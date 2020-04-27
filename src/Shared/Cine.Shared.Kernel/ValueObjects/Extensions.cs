using Cine.Shared.Kernel.WriteModels;

namespace Cine.Shared.Kernel.ValueObjects
{
    public static class Extensions
    {
        public static Time AsValueObject(this TimeWriteModel writeModel)
            => new Time(writeModel.Hour, writeModel.Minute);
    }
}
