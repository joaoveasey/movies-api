using Microsoft.AspNetCore.Mvc;
using movies_api.Model;
using movies_api.Repository;

namespace movies_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_movieRepository.GetMovies());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            if (_movieRepository.GetMovieById(id) == null)
                return NotFound();

            return Ok(_movieRepository.GetMovieById(id));
        }

        [HttpPost]
        public IActionResult PostMovie(Movie movie)
        {
            if (movie == null || movie.Title == null )
                return BadRequest();
            
            _movieRepository.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            if (_movieRepository.GetMovieById(id) == null)
                return NotFound();
            _movieRepository.DeleteMovie(id);
            return NoContent();
        }
    }
}
