using System;
using System.Collections.Generic;
using System.Linq;

namespace Cine.Modules.Cinemas.Api.DTO
{
    public class HallDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; } = Enumerable.Empty<SeatDto>();
    }
}
