using System;
using Cine.Reservations.Application.DTO.External;

namespace Cine.Reservations.Application.Queries.External
{
    public class GetUser : IQuery<CustomerDto>
    {
        public Guid UserId { get; set; }
    }
}
