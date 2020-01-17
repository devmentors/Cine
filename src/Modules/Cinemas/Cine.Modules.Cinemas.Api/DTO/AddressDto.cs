namespace Cine.Modules.Cinemas.Api.DTO
{
    public class AddressDto
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public string FullAddress => $"{Street}, {ZipCode} {City}";
    }
}
