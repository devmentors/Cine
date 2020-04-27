namespace Cine.Shared.Kernel.WriteModels
{
    public class TimeWriteModel
    {
        public int Hour { get; }
        public int Minute { get; }

        public TimeWriteModel(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
    }
}
