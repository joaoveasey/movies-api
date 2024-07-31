using Microsoft.AspNetCore.Mvc;
using movies_api.Interfaces;
using movies_api.Model;

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
        public ActionResult GetAllMovies()
        {
            var movies = _uof.MovieRepository.GetAll();

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult GetMovieById(int id)
        {
            if (_uof.MovieRepository.GetById(id) == null)
                return NotFound();

            return Ok(_uof.MovieRepository.GetById(id));
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody]Movie movie)
        {
            if (movie == null || movie.Title == null )
                return BadRequest();
            
            _uof.MovieRepository.Add(movie);
            _uof.Commit();
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut]
        public ActionResult UpdateMovie([FromBody] Movie movie)
        {
            if (movie.Id == null || movie.Id == 0 || movie.Title == null )
                return BadRequest();

            _uof.MovieRepository.Update(movie);
            _uof.Commit();
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            Movie movie = _uof.MovieRepository.GetById(id);

            if (_uof.MovieRepository.GetById(id) == null)
                return NotFound();

            _uof.MovieRepository.Delete(movie);
            _uof.Commit();
            return NoContent();
        }
    }
}
