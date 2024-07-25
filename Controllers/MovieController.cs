using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;

namespace movies_api.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public ActionResult GetMovies()
        {
            var movies = _movieRepository.GetMovies();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieById(int id)
        {
            if (_movieRepository.GetMovieById(id) == null)
                return NotFound();

            return Ok(_movieRepository.GetMovieById(id));
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody]Movie movie)
        {
            if (movie == null || movie.Title == null )
                return BadRequest();
            
            _movieRepository.AddMovie(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut]
        public ActionResult UpdateMovie([FromBody] Movie movie)
        {
            if (movie.Id == null || movie.Id == 0 || movie.Title == null )
                return BadRequest();

            _movieRepository.UpdateMovie(movie);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            Movie movie = _movieRepository.GetMovieById(id);

            if (_movieRepository.GetMovieById(id) == null)
                return NotFound();

            _movieRepository.DeleteMovie(movie);
            return NoContent();
        }
    }
}
