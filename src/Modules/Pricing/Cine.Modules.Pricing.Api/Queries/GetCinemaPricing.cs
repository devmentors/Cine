using System;
using Cine.Modules.Pricing.Api.DTO;
using Convey.CQRS.Queries;

namespace Cine.Modules.Pricing.Api.Queries
{
    public class GetCinemaPricing : IQuery<PricingDto>
    {
        public Guid CinemaId { get; set; }
    }
}
