using System.Text;

namespace Cine.Modules.Identity.Api.Options
{
    public class IdentityOptions
    {
        public string Secret { get; set; }
        public int ExpirationDays { get; set; }
        public byte[] Key => Encoding.ASCII.GetBytes(Secret);
    }
}
