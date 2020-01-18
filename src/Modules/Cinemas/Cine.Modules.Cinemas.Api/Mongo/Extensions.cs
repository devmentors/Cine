using System.Linq;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Modules.Cinemas.Api.Mongo.Documents;

namespace Cine.Modules.Cinemas.Api.Mongo
{
    public static class Extensions
    {
        public static CinemaDocument AsDocument(this CinemaDto dto)
            => new CinemaDocument
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = new AddressDocument
                {
                    Street = dto.Address.Street, City = dto.Address.City, ZipCode = dto.Address.ZipCode,
                },
                Halls = dto.Halls.Select(h => new HallDocument
                {
                    Id = h.Id,
                    Name = h.Name,
                    Seats = h.Seats.Select(s => new SeatDocument
                    {
                        Id = s.Id,
                        Row = s.Row,
                        Number = s.Number,
                        IsVip = s.IsVip,
                        RenderPositionX = s.RenderPosition.x,
                        RenderPositionY = s.RenderPosition.y,
                    })
                })
            };

        public static CinemaDto AsDto(this CinemaDocument document)
            => new CinemaDto
            {
                Id = document.Id,
                Name = document.Name,
                Address = new AddressDto
                {
                    Street = document.Address.Street,
                    City = document.Address.City,
                    ZipCode = document.Address.ZipCode,
                },
                Halls = document.Halls.Select(h => new HallDto
                {
                    Id = h.Id,
                    Name = h.Name,
                    Seats = h.Seats.Select(s => new SeatDto
                    {
                        Id = s.Id,
                        Row = s.Row,
                        Number = s.Number,
                        IsVip = s.IsVip,
                        RenderPosition = (s.RenderPositionX, s.RenderPositionY)
                    })
                })
            };

        public static HallDto AsDto(this HallDocument document)
            => new HallDto
            {
                Id = document.Id,
                Name = document.Name,
                Seats = document.Seats.Select(s => new SeatDto
                {
                    Id = s.Id,
                    Row = s.Row,
                    Number = s.Number,
                    IsVip = s.IsVip,
                    RenderPosition = (s.RenderPositionX, s.RenderPositionY)
                })
            };
    }
}
