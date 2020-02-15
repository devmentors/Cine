using System;
using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Modules.Cinemas.Api.Services;
using Cine.Modules.Cinemas.Api.Validators;
using Cine.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Cinemas.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemasService _service;
        private readonly ICinemaDtoValidator _validator;

        public CinemasController(ICinemasService service, ICinemaDtoValidator validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CinemaDto>> Get(Guid id)
        {
            var cinema = await _service.GetAsync(id).ThrowIfNotFoundAsync();
            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CinemaDto dto)
        {
            _validator.Validate(dto).ThrowIfInvalid();

            await _service.CreateAsync(dto);
            return Created(dto.Id.ToString(), null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, CinemaDto dto)
        {
            _validator.Validate(dto).ThrowIfInvalid();

            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
