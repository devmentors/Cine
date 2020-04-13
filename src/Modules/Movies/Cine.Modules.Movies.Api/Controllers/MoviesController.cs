using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Modules.Movies.Api.DTO;
using Cine.Modules.Movies.Api.Services;
using Cine.Modules.Movies.Api.Validators;
using Cine.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cine.Modules.Movies.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<MovieDto>>> Get(string searchPhrase)
        {
            var movies = await _service.SearchAsync(searchPhrase).ThrowIfNotFoundAsync();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MovieDto>> Get(Guid id)
        {
            var movie = await _service.GetAsync(id).ThrowIfNotFoundAsync();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieDto dto)
        {
            _validator.Validate(dto).ThrowIfInvalid();

            await _service.CreateAsync(dto);
            return Created(dto.Id.ToString(), null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, MovieDto dto)
        {
            dto.Id = id;
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
