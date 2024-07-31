using movies_api.Infra;
using movies_api.Interfaces;

namespace movies_api.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IMovieRepository? _movieRepository;
    public ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IMovieRepository MovieRepository 
    { 
        get 
        { 
            if(_movieRepository == null) 
                _movieRepository = new MovieRepository(_context);
            return _movieRepository;
        } 
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
