using System;
using Cine.Reservations.Application.DTO.External;
using Cine.Shared.Queries;

namespace Cine.Reservations.Application.Queries.External
{
    public class GetUser : IQuery<CustomerDto>
    {
        public Guid UserId { get; set; }
    }
}
