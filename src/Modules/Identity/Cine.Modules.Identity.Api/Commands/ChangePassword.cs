using Convey.CQRS.Commands;

namespace Cine.Modules.Identity.Api.Commands
{
    public class ChangePassword : ICommand
    {
        public string Username { get; }
        public string NewPassword { get; }

        public ChangePassword(string username, string newPassword)
        {
            Username = username;
            NewPassword = newPassword;
        }
    }
}
