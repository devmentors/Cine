using System;
using Cine.Reservations.Application.DTO.External;
using Convey.CQRS.Queries;

namespace Cine.Reservations.Application.Queries.External
{
    public class GetCustomer : IQuery<CustomerDto>
    {
        public Guid CustomerId { get; set; }
    }
}
