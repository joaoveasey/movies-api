using movies_api.Model;
using movies_api.Pagination;

namespace movies_api.Interfaces;

public interface IMovieRepository : IRepository<Movie>
{
    IEnumerable<Movie> GetMovies(MovieParameters movieParams);
}
