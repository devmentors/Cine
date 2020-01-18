using Cine.Modules.Cinemas.Api.DTO;
using Valit;

namespace Cine.Modules.Cinemas.Api.Validators
{
    public sealed class SeatDtoValidator : IValitator<SeatDto>
    {
        public IValitResult Validate(SeatDto dto, IValitStrategy strategy = null)
            => ValitRules<SeatDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(s => s.Row, _ => _
                    .MaxLength(1))
                .Ensure(s => s.Number, _ => _
                    .IsPositive())
                .For(dto)
                .Validate();
    }
}
