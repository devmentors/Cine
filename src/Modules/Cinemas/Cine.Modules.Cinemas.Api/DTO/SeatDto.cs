using System;

namespace Cine.Modules.Cinemas.Api.DTO
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        public string Row { get; set; }
        public int Number { get; set; }
        public bool IsVip { get; set; }
        public (int x, int y) RenderPosition { get; set; }

        public string Label => $"{Row} {Number}";
    }
}
