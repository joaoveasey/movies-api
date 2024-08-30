namespace movies_api.Interfaces;

public interface IUnitOfWork
{
    public IMovieRepository MovieRepository { get; }
    Task CommitAsync();
}

