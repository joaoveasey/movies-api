using Microsoft.AspNetCore.Connections;
using movies_api.Infra;
using movies_api.Interfaces;
using movies_api.Model;
using System.Configuration;

namespace movies_api.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context) 
        {
        }
    }
}
