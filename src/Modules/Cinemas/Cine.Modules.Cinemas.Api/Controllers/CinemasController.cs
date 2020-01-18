using System;
using System.Threading.Tasks;
using Cine.Modules.Cinemas.Api.DTO;
using Cine.Modules.Cinemas.Api.Services;
using Cine.Modules.Cinemas.Api.Validators;
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
        public async Task<ActionResult<CinemaDto>> Get([FromRoute] Guid id)
        {
            var cinema = await _service.GetAsync(id);

            if (cinema is null)
            {
                return NotFound();
            }

            return Ok(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CinemaDto dto)
        {
            var validation = _validator.Validate(dto);

            if (!validation.Succeeded)
            {
                return BadRequest(new {Errors = validation.ErrorMessages});
            }

            await _service.CreateAsync(dto);
            return Created($"cinemas/{dto.Id}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] CinemaDto dto)
        {
            dto.Id = id;

            var validation = _validator.Validate(dto);

            if (!validation.Succeeded)
            {
                return BadRequest(new {Errors = validation.ErrorMessages});
            }

            await _service.UpdateAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }
    }
}
