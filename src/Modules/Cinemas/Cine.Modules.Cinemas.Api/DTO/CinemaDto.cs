using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Cinemas.Api.DTO
{
    public class CinemaDto
    {
        [FromRoute]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; } = new AddressDto();
        public IEnumerable<HallDto> Halls { get; set; } = Enumerable.Empty<HallDto>();
    }
}
