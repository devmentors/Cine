using Cine.Modules.Movies.Api.DTO;
using Valit;

namespace Cine.Modules.Movies.Api.Validators
{
    public sealed class RateDtoValidator : IRateDtoValidator
    {
        public IValitResult Validate(RateDto dto, IValitStrategy strategy = null)
            => ValitRules<RateDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(r => r.Value, _ => _
                    .IsPositive()
                    .IsLessThanOrEqualTo(5))
                .For(dto)
                .Validate();
    }
}
