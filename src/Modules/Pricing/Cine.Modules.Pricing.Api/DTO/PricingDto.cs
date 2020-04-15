using System;

namespace Cine.Modules.Pricing.Api.DTO
{
    public class PricingDto
    {
        public Guid CinemaId { get; set; }
        public decimal NormalSeatPrice { get; set; } = 20;
        public decimal VipSeatPrice { get; set; } = 25;
    }
}
