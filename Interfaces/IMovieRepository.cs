using movies_api.Model;

namespace movies_api.Interfaces;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie GetMovieById(int id);
    void AddMovie(Movie movie);
    void UpdateMovie(Movie movie);
    void DeleteMovie(Movie movie);
}
