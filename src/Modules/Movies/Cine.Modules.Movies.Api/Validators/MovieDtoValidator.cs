using Cine.Modules.Movies.Api.DTO;
using Valit;

namespace Cine.Modules.Movies.Api.Validators
{
    public sealed class MovieDtoValidator : IMovieDtoValidator
    {
        public IValitResult Validate(MovieDto dto, IValitStrategy strategy = null)
            => ValitRules<MovieDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(m => m.Id, _ => _
                    .IsNotEmpty())
                .Ensure(m => m.Title, _ => _
                    .Required())
                .Ensure(m => m.Length, _ => _
                    .IsPositive())
                .For(dto)
                .Validate();

    }
}
