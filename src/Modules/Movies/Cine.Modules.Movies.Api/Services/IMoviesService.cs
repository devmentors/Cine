using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cine.Modules.Movies.Api.DTO;

namespace Cine.Modules.Movies.Api.Services
{
    public interface IMoviesService
    {
        Task<MovieDto> GetAsync(Guid id);
        Task<IEnumerable<MovieDto>> SearchAsync(string searchPhrase);
        Task CreateAsync(MovieDto dto);
        Task UpdateAsync(MovieDto dto);
        Task RateAsync(Guid movieId, RateDto rate);
        Task DeleteAsync(Guid id);
    }
}
