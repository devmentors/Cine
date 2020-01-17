using System;
using System.Collections.Generic;

namespace Cine.Modules.Cinemas.Api.DTO
{
    public class HallDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; }
    }
}
