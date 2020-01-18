using Cine.Modules.Cinemas.Api.DTO;
using Valit;

namespace Cine.Modules.Cinemas.Api.Validators
{
    public sealed class AddressDtoValidator : IValitator<AddressDto>
    {
        public IValitResult Validate(AddressDto dto, IValitStrategy strategy = null)
            => ValitRules<AddressDto>
                .Create()
                .WithStrategy(s => s.Complete)
                .Ensure(a => a.City, _ => _
                    .Required())
                .Ensure(a => a.Street, _ => _
                    .Required())
                .Ensure(a => a.ZipCode, _ => _
                    .Required())
                .For(dto)
                .Validate();
    }
}
