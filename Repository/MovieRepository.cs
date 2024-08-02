using Microsoft.AspNetCore.Connections;
using movies_api.Infra;
using movies_api.Interfaces;
using movies_api.Model;
using movies_api.Pagination;
using System.Configuration;

namespace movies_api.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context) 
        {
        }

        public IEnumerable<Movie> GetMovies(MovieParameters movieParams)
        {
            return GetAll()
                .OrderBy(x => x.Id)
                .Skip((movieParams.PageNumber - 1) * movieParams.PageSize) // used to calculate how many items has to be skipped from data collection acordding to size and number of the pages.
                .Take(movieParams.PageSize)
                .ToList();
        }
    }
}
