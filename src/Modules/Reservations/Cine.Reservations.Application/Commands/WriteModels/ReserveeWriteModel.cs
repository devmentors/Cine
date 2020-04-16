namespace Cine.Reservations.Application.Commands.WriteModels
{
    public class ReserveeWriteModel
    {
        public string FullName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }

        public ReserveeWriteModel(string fullName, string email, string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
