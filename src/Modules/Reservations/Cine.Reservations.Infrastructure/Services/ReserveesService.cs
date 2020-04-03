using System;
using System.Threading.Tasks;
using Cine.Reservations.Application.DTO.External;
using Cine.Reservations.Application.Queries.External;
using Cine.Reservations.Core.Services;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.Modules;

namespace Cine.Reservations.Infrastructure.Services
{
    internal sealed class ReserveesService : IReserveesService
    {
        private readonly IModuleClient _client;

        public ReserveesService(IModuleClient client)
            => _client = client;

        public async Task<Reservee> GetAsync(Guid customerId)
        {
            var customer = await _client.GetAsync<CustomerDto>("modules/customers/details", new GetCustomer
            {
                CustomerId = customerId
            });

            return new Reservee(customer.FullName, customer.Email, customer.PhoneNumber);
        }
    }
}
