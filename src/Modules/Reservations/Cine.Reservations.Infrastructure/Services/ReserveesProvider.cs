using System;
using System.Threading.Tasks;
using Cine.Reservations.Application.DTO.External;
using Cine.Reservations.Application.Queries.External;
using Cine.Reservations.Core.Services;
using Cine.Reservations.Core.ValueObjects;
using Cine.Shared.Modules;

namespace Cine.Reservations.Infrastructure.Services
{
    internal sealed class ReserveesProvider : IReserveesProvider
    {
        private readonly IModuleClient _client;

        public ReserveesProvider(IModuleClient client)
            => _client = client;

        public async Task<Reservee> GetAsync(Guid customerId)
        {
            var customer = await _client.GetAsync<CustomerDto>("modules/identity/details", new GetUser
            {
                UserId = customerId
            });

            return new Reservee(customer.FullName, customer.Email, customer.PhoneNumber);
        }
    }
}
