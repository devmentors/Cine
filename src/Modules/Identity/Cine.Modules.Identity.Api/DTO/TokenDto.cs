using System;

namespace Cine.Modules.Identity.Api.DTO
{
    public class TokenDto
    {
        public string Token { get; set; }
        public string Issuer { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
