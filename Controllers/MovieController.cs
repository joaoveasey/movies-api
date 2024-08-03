using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;
using movies_api.DTOs;
using movies_api.Pagination;
using AutoMapper;

namespace movies_api.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public MovieController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uof = unitOfWork ?? throw new ArgumentNullException();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetAllMovies()
        {
            var movies = await _uof.MovieRepository.GetAllAsync();

            if (movies is null)
                return NotFound("No movies found.");

            var moviesDTO = _mapper.Map<IEnumerable<Movie>>(movies);

            return Ok(moviesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovieById(int id)
        {
            var movie = await _uof.MovieRepository.GetByIdAsync(id);

            if (movie is null)
                return NotFound("No movie found with ID: " + id);

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies ([FromQuery] MovieParameters movieParameters)
        {
            var movies = await _uof.MovieRepository.GetMoviesAsync(movieParameters);

            var moviesDTO = _mapper.Map<IEnumerable<MovieDTO>>(movies);

            return Ok(moviesDTO);
        }

        [HttpGet("filter/year")]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMoviesFilteredByYear([FromQuery] MovieFilteredByYear movieFilteredByYear)
        {
            var movies = await _uof.MovieRepository.GetMoviesFilteredByYearAsync(movieFilteredByYear);

            var moviesDTO = _mapper.Map<IEnumerable<MovieDTO>>(movies);

            return Ok(moviesDTO);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> AddMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = _mapper.Map<Movie>(movieDTO);

            var createdMovie = _uof.MovieRepository.Add(movie);
            await _uof.CommitAsync();

            var newMovieDTO = _mapper.Map<MovieDTO>(createdMovie);

            return Ok(newMovieDTO);
        }

        [HttpPut]
        public async Task<ActionResult<MovieDTO>> UpdateMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = _mapper.Map<Movie>(movieDTO);

            var updatedMovie = _uof.MovieRepository.Update(movie);
            await _uof.CommitAsync();

            var updatedMovieDTO = _mapper.Map<MovieDTO>(updatedMovie);

            return Ok(updatedMovieDTO);            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieDTO>> DeleteMovie(int id)
        {
            var movie = await _uof.MovieRepository.GetByIdAsync(id);

            if (movie is null)
                return NotFound("No movie found with ID: " + id);

            var deletedMovie = _uof.MovieRepository.Delete(movie);
            await _uof.CommitAsync();

            var deletedMovieDTO = _mapper.Map<MovieDTO>(deletedMovie);

            return Ok(deletedMovieDTO);
        }
    }
}
