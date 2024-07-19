using movies_api.Model;

namespace movies_api.Repository;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovieById(int id);
    void AddMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(int id);
}
