namespace Cine.Modules.Identity.Api.Services
{
    public interface IPasswordsService
    {
        string HashPassword(string password, byte[] salt);
        byte[] CreateSalt();
    }
}
