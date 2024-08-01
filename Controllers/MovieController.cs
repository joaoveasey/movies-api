using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;
using movies_api.DTOs;
using movies_api.DTOs.Mappings;
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
        public ActionResult<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var movies = _uof.MovieRepository.GetAll();

            if (movies is null)
                return NotFound("No movies found.");

            var moviesDTO = _mapper.Map<IEnumerable<Movie>>(movies);

            return Ok(moviesDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Movie>> GetMovieById(int id)
        {
            var movie = _uof.MovieRepository.GetById(id);

            if (movie is null)
                return NotFound("No movie found with ID: " + id);

            var movieDTO = _mapper.Map<MovieDTO>(movie);

            return Ok(movieDTO);
        }

        [HttpPost]
        public ActionResult<MovieDTO> AddMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = _mapper.Map<Movie>(movieDTO);

            var createdMovie = _uof.MovieRepository.Add(movie);
            _uof.Commit();

            var newMovieDTO = _mapper.Map<MovieDTO>(createdMovie);

            return Ok(newMovieDTO);
        }

        [HttpPut]
        public ActionResult<MovieDTO> UpdateMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = _mapper.Map<Movie>(movieDTO);

            var updatedMovie = _uof.MovieRepository.Update(movie);
            _uof.Commit();

            var updatedMovieDTO = _mapper.Map<MovieDTO>(updatedMovie);

            return Ok(updatedMovieDTO);            
        }

        [HttpDelete("{id}")]
        public ActionResult<MovieDTO> DeleteMovie(int id)
        {
            var movie = _uof.MovieRepository.GetById(id);

            if (movie is null)
                return NotFound("No movie found with ID: " + id);

            var deletedMovie = _uof.MovieRepository.Delete(movie);
            _uof.Commit();

            var deletedMovieDTO = _mapper.Map<MovieDTO>(deletedMovie);

            return Ok(deletedMovieDTO);
        }
    }
}
