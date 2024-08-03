using movies_api.Model;
using movies_api.Pagination;

namespace movies_api.Interfaces;

public interface IMovieRepository : IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetMoviesAsync(MovieParameters movieParams);
    Task<IEnumerable<Movie>> GetMoviesFilteredByYearAsync(MovieFilteredByYear movieFilteredByYear);
}
