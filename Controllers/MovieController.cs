using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;
using movies_api.DTOs;
using movies_api.DTOs.Mappings;

namespace movies_api.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public MovieController(IUnitOfWork unitOfWork)
        {
            _uof = unitOfWork ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetAllMovies()
        {
            var movies = _uof.MovieRepository.GetAll();

            if (movies is null)
                return NotFound("No movies found.");

            var moviesDTO = movies.ToMovieDTOList();

            return Ok(moviesDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Movie>> GetMovieById(int id)
        {
            var movie = _uof.MovieRepository.GetById(id);

            if (movie is null)
                return NotFound("No movie found with ID: " + id);

            var movieDTO = movie.ToMovieDTO();

            return Ok(movieDTO);
        }

        [HttpPost]
        public ActionResult<MovieDTO> AddMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = movieDTO.ToMovie();

            var createdMovie = _uof.MovieRepository.Add(movie);
            _uof.Commit();

            var newMovieDTO = createdMovie.ToMovieDTO();

            return Ok(newMovieDTO);
        }

        [HttpPut]
        public ActionResult<MovieDTO> UpdateMovie(MovieDTO movieDTO)
        {
            if (movieDTO is null)
                return BadRequest("Invalid data.");

            var movie = movieDTO.ToMovie();

            var updatedMovie = _uof.MovieRepository.Update(movie);
            _uof.Commit();

            var updatedMovieDTO = updatedMovie.ToMovieDTO();

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

            var deletedMovieDTO = deletedMovie.ToMovieDTO();

            return Ok(deletedMovieDTO);
        }
    }
}
