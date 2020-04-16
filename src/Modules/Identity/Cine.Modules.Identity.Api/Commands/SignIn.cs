using System.Windows.Input;

namespace Cine.Modules.Identity.Api.Commands
{
    public class SignIn : ICommand
    {
        public string Username { get; }
        public string Password { get; }

        public SignIn(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
