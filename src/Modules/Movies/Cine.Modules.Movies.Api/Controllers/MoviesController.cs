using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Services;
using Cine.Modules.Movies.Api.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Movies.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieDtoValidator _validator;
        private readonly IMoviesService _service;

        public MoviesController(IMovieDtoValidator validator, IMoviesService service)
        {
            _validator = validator;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Get([FromQuery] string searchPhrase)
            => Ok(await _service.SearchAsync(searchPhrase));

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> Get([FromRoute] Guid id)
            => Ok(await _service.GetAsync(id));

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MovieDto dto)
        {
            var validation = _validator.Validate(dto);

            if (!validation.Succeeded)
            {
                return BadRequest(new { Errors = validation.ErrorMessages });
            }

            await _service.CreateAsync(dto);

            return Created($"movies/{dto.Id}", null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] MovieDto dto)
        {
            dto.Id = id;

            var validation = _validator.Validate(dto);

            if (!validation.Succeeded)
            {
                return BadRequest(new { Errors = validation.ErrorMessages });
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
