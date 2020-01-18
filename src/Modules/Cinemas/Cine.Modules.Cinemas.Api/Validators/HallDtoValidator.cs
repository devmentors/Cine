using Cine.Modules.Cinemas.Api.DTO;
using Valit;

namespace Cine.Modules.Cinemas.Api.Validators
{
    public sealed class HallDtoValidator : IValitator<HallDto>
    {
        public IValitResult Validate(HallDto dto, IValitStrategy strategy = null)
            => ValitRules<HallDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(h => h.Name, _ => _
                    .Required())
                .Ensure(s => s.Seats, _ => _
                    .MinItems(1))
                .EnsureFor(s => s.Seats, new SeatDtoValidator())
                .For(dto)
                .Validate();
    }
}
