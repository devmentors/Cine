using Cine.Modules.Cinemas.Api.DTO;
using Valit;

namespace Cine.Modules.Cinemas.Api.Validators
{
    public sealed class CinemaDtoValidator : ICinemaDtoValidator
    {
        public IValitResult Validate(CinemaDto dto, IValitStrategy strategy = null)
            => ValitRules<CinemaDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(c => c.Id, _ => _
                    .IsNotEmpty())
                .Ensure(c => c.Name, _ => _
                    .Required())
                .Ensure(c => c.Address, _ => _
                    .Required())
                .Ensure(c => c.Address, new AddressDtoValidator())
                .Ensure(c => c.Halls, _ => _
                    .Required())
                .EnsureFor(c => c.Halls, new HallDtoValidator())
                .For(dto)
                .Validate();
    }
}
