using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;

namespace movies_api.Controllers
{
    [ApiController]
    [Route("api/v1/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MovieController(IMovieRepository movieRepository)
        {
            _repository = movieRepository ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public ActionResult GetAllMovies()
        {
            var movies = _repository.GetAll();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieById(int id)
        {
            if (_repository.GetById(id) == null)
                return NotFound();

            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody]Movie movie)
        {
            if (movie == null || movie.Title == null )
                return BadRequest();
            
            _repository.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut]
        public ActionResult UpdateMovie([FromBody] Movie movie)
        {
            if (movie.Id == null || movie.Id == 0 || movie.Title == null )
                return BadRequest();

            _repository.Update(movie);
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            Movie movie = _repository.GetById(id);

            if (_repository.GetById(id) == null)
                return NotFound();

            _repository.Delete(movie);
            return NoContent();
        }
    }
}
