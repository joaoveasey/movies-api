using movies_api.DTOs;
using movies_api.Model;
using System.Runtime.CompilerServices;

namespace movies_api.DTOs.Mappings;

public static class MovieDTOMappingExtensions
{
    public static MovieDTO? ToMovieDTO(this Movie movie)
    {
        if (movie is null)
            return null;

        return new MovieDTO
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Genre = movie.Genre,
            Director = movie.Director,
            Duration = movie.Duration,
            Rating = movie.Rating
        };
    }

    public static Movie? ToMovie(this MovieDTO movieDTO)
    {
        if (movieDTO is null)
            return null;

        return new Movie
        {
            Id = movieDTO.Id,
            Title = movieDTO.Title,
            Year = movieDTO.Year,
            Genre = movieDTO.Genre,
            Director = movieDTO.Director,
            Duration = movieDTO.Duration,
            Rating = movieDTO.Rating
        };
    }

    public static IEnumerable<MovieDTO> ToMovieDTOList(this IEnumerable<Movie> movies)
    {
        if (movies is null || !movies.Any())
            return new List<MovieDTO>();

        return movies.Select(movie => new MovieDTO
        {
            Id = movie.Id,
            Title = movie.Title,
            Year = movie.Year,
            Genre = movie.Genre,
            Director = movie.Director,
            Duration = movie.Duration,
            Rating = movie.Rating
        }).ToList();
    }
}
